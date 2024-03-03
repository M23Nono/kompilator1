using System;

namespace Laba1
{
    internal class AboutBox
    {
        public string ProductName { get; internal set; }
        public string Version { get; internal set; }
        public string Copyright { get; internal set; }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}