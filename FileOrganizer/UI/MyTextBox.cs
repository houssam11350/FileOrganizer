using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace FileOrganizer.UI
{
    public partial class MyTextBox : TextBox
    {
        #region private globals

        private System.Timers.Timer DelayTimer; // used for the delay
        private bool TimerElapsed = false; // if true OnTextChanged is fired.
        private bool KeysPressed = false; // makes event fire immediately if it wasn't a keypress
        private int DELAY_TIME = 2000;

        #endregion
        //public int RightMargin
        //{
        //    set { this.Margin = new Padding(this.Margin.Left, this.Margin.Top,  value , this.Margin.Bottom); }
        //    get { return this.Margin.Right; }
        //}
        public MyTextBox()
        {
            InitializeComponent();
            DelayTimer = new System.Timers.Timer(DELAY_TIME);
            DelayTimer.Elapsed += new ElapsedEventHandler(DelayTimer_Elapsed);

        }

        public MyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DelayTimer = new System.Timers.Timer(DELAY_TIME);
            DelayTimer.Elapsed += new ElapsedEventHandler(DelayTimer_Elapsed);

        }

        // Delay property
        public int Delay
        {
            set { DELAY_TIME = value; }
        }

        public event EventHandler ClickButton
        {
            add
            {
                this.myButton.Click += value;
            }
            remove
            {
                this.myButton.Click -= value;
            }
        }

        #region event handlers

        void DelayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // stop timer.
            DelayTimer.Enabled = false;

            // set timer elapsed to true, so the OnTextChange knows to fire
            TimerElapsed = true;

            // use invoke to get back on the UI thread.
            this.Invoke(new DelayOverHandler(DelayOver), null);
        }

        #endregion

        #region overrides

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!DelayTimer.Enabled)
                DelayTimer.Enabled = true;
            else
            {
                DelayTimer.Enabled = false;
                DelayTimer.Enabled = true;
            }

            KeysPressed = true;

            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            // if the timer elapsed or text was changed by something besides a keystroke
            // fire base.OnTextChanged
            if (TimerElapsed || !KeysPressed)
            {
                TimerElapsed = false;
                KeysPressed = false;
                base.OnTextChanged(e);
            }
        }

        #endregion

        #region delegates

        public delegate void DelayOverHandler();

        #endregion

        #region private helpers

        private void DelayOver()
        {
            OnTextChanged(new EventArgs());
        }

        #endregion
        
        protected override void OnCreateControl()
        {
            if (!this.Controls.Contains(this.myButton))
            {
                this.Controls.Add(this.myButton);
                //size of control - size control button +10
                //this.Margin.Right  = this.Size.Width - (this.myButton.Size.Width + 10);
                //this.Margin = new Padding(this.Margin.Left, this.Margin.Top, this.Size.Width - (this.myButton.Size.Width + 10), this.Margin.Bottom);
            }

            base.OnCreateControl();
        }
        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                this.myButton.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }

        }

        private void myButton_Click(object sender, EventArgs e)
        {
            this.Text = String.Empty;
        }

    }
}
