using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors;

namespace LinqServerMode
{
    public partial class Main : XtraForm
    {
        public Main()
        {
            InitializeComponent();

            linqInstantFeedbackSource.KeyExpression = "SupplierID";
            gridControl1.DataSource = linqInstantFeedbackSource;
        }

       
        void OnGetQueryable(object sender, GetQueryableEventArgs e)
        {
            NorthwindClassesDataContext dt = new NorthwindClassesDataContext();
            e.QueryableSource = dt.Suppliers;
            e.Tag = dt;  
        }

        void OnDismissQueryable(object sender, GetQueryableEventArgs e)
        {
            (e.Tag as NorthwindClassesDataContext).Dispose();
        }
    }
}
