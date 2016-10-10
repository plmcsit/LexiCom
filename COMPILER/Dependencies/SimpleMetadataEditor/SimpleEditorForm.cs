// Copyright 2008 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
// 

// Copyright 2007 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at /arcgis/developerkit/userestrictions.
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimpleEditorCS
{
  /// <summary>
  /// A simple custom metadata editing form.
  /// </summary>
  public partial class SimpleEditorForm : Form
  {
    /// <summary>
    /// A property for getting and setting the txtAbstract text box's value.
    /// </summary>
    public String Abstract
    {
      get { return txtAbstract.Text; }
      set { txtAbstract.Text = value; }
    }

    /// <summary>
    /// A property for getting and setting the txtTitle text box's value.
    /// </summary>
    public String Title
    {
      get { return txtTitle.Text; }
      set { txtTitle.Text = value; }
    }

    /// <summary>
    /// The default constructor.
    /// </summary>
    public SimpleEditorForm()
    {
      InitializeComponent();
    }
  }
}