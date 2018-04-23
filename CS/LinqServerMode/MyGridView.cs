using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraGrid.Localization;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;

namespace LinqServerMode
{
    public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        string lastError = string.Empty;

        public MyGridView() : this(null) { }
        public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) { }

        protected override string ViewName { get { return "MyGridView"; } }

        protected override void CheckDataControllerError()
        {
            // show a tooltip
            ShowDataControllerError();
        }

        protected override void OnDataControllerError(string lastError)
        {
            //additional code
           // XtraMessageBox.Show(lastError);
        }

        protected new void ShowDataControllerError()
        {
            if (GridControl == null || !GridControl.IsHandleCreated) return;
            if (lastError != DataController.LastErrorText)
            {
                lastError = DataController.LastErrorText;
                if (!string.IsNullOrEmpty(lastError)) OnDataControllerError(lastError);
            }
            if (DataController.LastErrorText == "")
            {
                if (GridControl.EditorHelper.RealToolTipController.ActiveObject == null)
                    HideHint();
                return;
            }

            ToolTipControllerShowEventArgs ee = new ToolTipControllerShowEventArgs();
            ee.AutoHide = false;
            ee.Title = "Error";
            ee.ToolTipLocation = ToolTipLocation.RightTop;
            //set an exception text here
            ee.ToolTip = string.Format(GridLocalizer.Active.GetLocalizedString(GridStringId.ServerRequestError),
                DataController.LastErrorText);
            ee.ToolTipType = ToolTipType.SuperTip;
            ee.IconType = ToolTipIconType.Error;
            ee.IconSize = ToolTipIconSize.Small;
            ToolTipController.DefaultController.ShowHint(ee, GridControl.PointToScreen(new Point(ViewRect.Left, ViewRect.Bottom)));
            lastError = DataController.LastErrorText;
        }

        public new MyGridControl GridControl
        {
            get { return base.GridControl as MyGridControl; }
            set { base.GridControl = value; }
        }
    }
}
