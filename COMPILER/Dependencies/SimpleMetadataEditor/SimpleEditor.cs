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
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.esriSystem;

namespace SimpleEditorCS
{
  /// <summary>
  /// A simple custom metadata editor.
  /// </summary>
  [Guid("8141cdcb-d8ab-44bc-8a46-979929338aad")]
  [ClassInterface(ClassInterfaceType.None)]
  [ProgId("CustomMetadataEditorCS.SimpleEditor")]
  public class SimpleEditor : IMetadataEditor
  {
    #region IMetadataEditor Members
    /// <summary>
    /// The name of the metadata editor.
    /// </summary>
    public String Name
    {
      get { return "Simple Editor"; }
    }

    /// <summary>
    /// Displays the metadata editing form.
    /// </summary>
    /// <param name="propertySet">The metadata property set to edit.</param>
    /// <param name="hwnd">The parent window handle.</param>
    /// <returns>True if the metadata was modified, false otherwise.</returns>
    public Boolean Edit(IPropertySet propertySet, int hwnd)
    {
      // Get the title and abstract properties from the property set.
      // IPropertySet.GetProperty will return the properties as object
      // arrays, since metadata can contain multiple properties with the
      // same name.
      object[] titleProperties = (object[])propertySet.GetProperty("idinfo/citation/citeinfo/title");
      object[] abstractProperties = (object[])propertySet.GetProperty("idinfo/descript/abstract");
      
      // The simple editor form only allows one title and one abstract, so
      // use the first value found for each property to populate the form.
      SimpleEditorForm simpleEditorForm = new SimpleEditorForm();
      if (titleProperties != null && titleProperties.Length > 0)
      {
        simpleEditorForm.Title = Convert.ToString(titleProperties[0]);
      }
      if (abstractProperties != null && abstractProperties.Length > 0)
      {
        simpleEditorForm.Abstract = Convert.ToString(abstractProperties[0]);
      }

      // Show the simple editor form. If OK is clicked, set the metadata's
      // values to the Title and Abstract properties of the form.
      if (simpleEditorForm.ShowDialog() == DialogResult.OK)
      {
        propertySet.SetProperty("idinfo/citation/citeinfo/title", simpleEditorForm.Title);
        propertySet.SetProperty("idinfo/descript/abstract", simpleEditorForm.Abstract);

        // The return value indicates whether any changes have been made.
        return true;
      }

      return false;
    }
    #endregion

    #region COM Registration Function(s)
    /// <summary>
    /// Required for component category registration.
    /// </summary>
    /// <param name="registerType">The Type to register.</param>
    [ComRegisterFunction()]
    [ComVisible(false)]
    static void RegisterFunction(Type registerType)
    {
      string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
      MetadataEditor.Register(regKey);
    }

    /// <summary>
    /// Required for component category unregistration.
    /// </summary>
    /// <param name="registerType">The type to unregister.</param>
    [ComUnregisterFunction()]
    [ComVisible(false)]
    static void UnregisterFunction(Type registerType)
    {
      string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
      MetadataEditor.Unregister(regKey);
    }
    #endregion
  }
}
