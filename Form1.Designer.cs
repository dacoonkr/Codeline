
namespace Codeline
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.load = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.current = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(191, 12);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(173, 26);
            this.load.TabIndex = 0;
            this.load.Text = "Load LineCount File";
            this.load.UseVisualStyleBackColor = true;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(12, 12);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(173, 26);
            this.create.TabIndex = 1;
            this.create.Text = "New LineCount File";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.Font = new System.Drawing.Font("굴림", 20F);
            this.current.Location = new System.Drawing.Point(12, 50);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(269, 27);
            this.current.TabIndex = 2;
            this.current.Text = "Open LineCount File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 454);
            this.Controls.Add(this.current);
            this.Controls.Add(this.create);
            this.Controls.Add(this.load);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CODE LINE v1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Label current;
    }
}

