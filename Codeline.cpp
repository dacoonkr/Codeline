#include <iostream>
#include <filesystem>
#include <map>
#include <string>
#include <set>
#include <tuple>
#include <Windows.h>
using namespace std;
namespace fs = filesystem;

set<string> needtocount;
set<string> ignorelist;

              //파일수, 줄수, 글자수
map<string, tuple<int, int, int>> file_exts;

string getdir() {
    char buffer[MAX_PATH];
    GetModuleFileNameA(NULL, buffer, MAX_PATH);
    std::string::size_type pos = std::string(buffer).find_last_of("\\/");

    return std::string(buffer).substr(0, pos);
}

void getSetting() {
    string ignorename = "";
    int mode = 0;

    FILE* fp;
    int line = 1, chars = 0;
    char c;
    fp = fopen("linecount.txt", "r");
    while ((c = fgetc(fp)) != EOF) {
        if (c == '\n') {
            if (ignorename.length() > 0) {
                if (ignorename == "+") {
                    mode = 0;
                }
                else if (ignorename == "-") {
                    mode = 1;
                }
                else {
                    if (mode == 0) {
                        needtocount.insert(ignorename);
                    }
                    else if (mode == 1) {
                        ignorelist.insert(ignorename);
                    }
                }
                ignorename = "";
            }
        }
        else ignorename.push_back(c);
    }
    if (ignorename.length() > 0) {
        ignorelist.insert(ignorename);
        ignorename = "";
    }
    fclose(fp);
}

pair<int, int> getTotal(const char* name) {
    try {
        FILE* fp;
        int line = 1, chars = 0;
        char c;
        fp = fopen(name, "r");
        while ((c = fgetc(fp)) != EOF) {
            if (c == '\n') line++;
            else chars++;
        }
        fclose(fp);
        return make_pair(line, chars);
    }
    catch (...) {
        return make_pair(0, 0);
    }
}

void search(string path) {
    for (const auto& entry : fs::directory_iterator(path)) {
        try {
            if (ignorelist.find(entry.path().filename().string()) == ignorelist.end()) {
                search(entry.path().string());
            }
        }
        catch (...) {
            string exts = entry.path().extension().string();
            if (needtocount.find(exts) != needtocount.end()) {
                pair<int, int> filecount = getTotal(entry.path().string().c_str());

                if (file_exts.find(exts) == file_exts.end()) {
                    get<0>(file_exts[exts]) = 0;
                    get<1>(file_exts[exts]) = 0;
                    get<2>(file_exts[exts]) = 0;
                }
                get<0>(file_exts[exts])++;
                get<1>(file_exts[exts]) += filecount.first;
                get<2>(file_exts[exts]) += filecount.second;

                printf("%d줄 %d글자 %s\n", filecount.first, filecount.second, entry.path().filename().string().c_str());
            }
        }
    }
}

int main() {
    getSetting();
    printf("Load Setting...\n\n");

    printf("Ignore Lists: ");
    for (auto& i : ignorelist)
        printf("%s ", i.c_str());
    printf("\n");

    printf("File Extensions: ");
    for (auto& i : needtocount) 
        printf("%s ", i.c_str());
    printf("\n\n");

    search(getdir());
    printf("\n");

    printf("  Ext    Files    Lines    Chars\n");
    printf("--------------------------------\n");
    for (auto& i : file_exts) {
        printf("%5s %8d %8d %8d\n", i.first.c_str(), get<0>(i.second), get<1>(i.second), get<2>(i.second));
    }

    printf("\n\n");
}