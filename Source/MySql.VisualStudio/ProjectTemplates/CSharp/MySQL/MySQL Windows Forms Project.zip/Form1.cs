﻿/*
 * ++++++++++++++++++++++++++++++++++++++++++++++++++
 * This code is generated by a tool and is provided "as is", without warranty of any kind,
 * express or implied, including but not limited to the warranties of merchantability,
 * fitness for a particular purpose and non-infringement.
 * In no event shall the authors or copyright holders be liable for any claim, damages or
 * other liability, whether in an action of contract, tort or otherwise, arising from,
 * out of or in connection with the software or the use or other dealings in the software.
 * ++++++++++++++++++++++++++++++++++++++++++++++++++
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
// <WizardGeneratedCode>Namespace_UserCode</WizardGeneratedCode>

namespace $safeprojectname$
{
  public partial class Form1 : Form
  {
    // <WizardGeneratedCode>Private Variables Frontend</WizardGeneratedCode>

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // <WizardGeneratedCode>Form_Load</WizardGeneratedCode>

    }

    private void Save_Click(object sender, EventArgs e)
    {
      if (!this.Validate()) return;
      // <WizardGeneratedCode>Save Event</WizardGeneratedCode>

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = false;
    }

    // <WizardGeneratedCode>Validation Events</WizardGeneratedCode>



    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
    {
      // <WizardGeneratedCode>Add Event</WizardGeneratedCode>
    }
  }
}
