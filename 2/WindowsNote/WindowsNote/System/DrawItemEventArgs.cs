namespace System
{
    internal class DrawItemEventArgs
    {
        private Action<object, EventArgs, Windows.Forms.DrawItemEventArgs> newToolStripMenuItem_Click;

        public DrawItemEventArgs(Action<object, EventArgs, Windows.Forms.DrawItemEventArgs> newToolStripMenuItem_Click)
        {
            this.newToolStripMenuItem_Click = newToolStripMenuItem_Click;
        }
    }
}