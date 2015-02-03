using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO.IsolatedStorage;
using System.Configuration.Install;

namespace TaskBarManager
{
    [RunInstaller(true)]
    public partial class MyInstaller : Installer
    {
        public MyInstaller()
        {
            InitializeComponent();
        }

        public override void Uninstall(IDictionary savedState)
        {
#if false // not used
            var isf = IsolatedStorageFile.GetStore(
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.User,
                (Type)null,
                (Type)null);
            isf.Remove();
#endif
            base.Uninstall(savedState);
        }
    }
}
