﻿//===============================================================================================================
// System  : Sandcastle Help File Builder Visual Studio Package
// File    : Help1WebsitePropertiesPageControl.cs
// Author  : Eric Woodruff
// Updated : 03/08/2014
// Note    : Copyright 2011-2014, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This user control is used to edit the Help 1 and Website category properties.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code.  It can also be found at the project website: https://GitHub.com/EWSoftware/SHFB.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
//===============================================================================================================
// 03/27/2011  EFW  Created the code
// 03/08/2014  EFW  Updated for use with the Open XML file format
//===============================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SandcastleBuilder.Utils;

namespace SandcastleBuilder.Package.PropertyPages
{
    /// <summary>
    /// This is used to edit the Help 1, Website, and Open XML category project properties
    /// </summary>
    /// <remarks>The only Open XML property is for SDK links so we re-use the Website link type</remarks>
    [Guid("690D191C-5614-4A82-92A4-96EB519828CA")]
    public partial class Help1WebsitePropertiesPageControl : BasePropertyPage
    {
        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        public Help1WebsitePropertiesPageControl()
        {
            InitializeComponent();

            // Set the maximum size to prevent an unnecessary vertical scrollbar
            this.MaximumSize = new System.Drawing.Size(2048, this.Height);

            this.Title = "Help 1/Website";

            cboWebsiteSdkLinkType.BindingContext = new BindingContext();

            cboHtmlSdkLinkType.DisplayMember = cboWebsiteSdkLinkType.DisplayMember = "Value";
            cboHtmlSdkLinkType.ValueMember = cboWebsiteSdkLinkType.ValueMember = "Key";

            cboHtmlSdkLinkType.DataSource = cboWebsiteSdkLinkType.DataSource = (new Dictionary<string, string> {
                { HtmlSdkLinkType.Msdn.ToString(), "Online links to MSDN help topics" },
                { HtmlSdkLinkType.None.ToString(), "No SDK links" } }).ToList();
        }
        #endregion

        #region Method overrides
        //=====================================================================

        /// <inheritdoc />
        public override bool ShowHelp()
        {
            // If a website control has the focus, show the Website help page.  If not, show the Help 1 help page
            if(cboWebsiteSdkLinkType.Focused)
                this.HelpKeyword = "f818e4d1-3457-4be6-a833-1b700f1e2f18";
            else
                this.HelpKeyword = "7d28bf8f-923f-44c1-83e1-337a416947a1";

            return base.ShowHelp();
        }
        #endregion
    }
}
