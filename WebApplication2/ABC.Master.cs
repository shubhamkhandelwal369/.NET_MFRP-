using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ABC : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Add")
            {
                Response.Redirect("http://localhost:51016/SignupPage.aspx");
            }
            else if (DropDownList1.Text == "Home")
            {
                Response.Redirect("http://localhost:51016/HomePage.aspx");
            }
            else if (DropDownList1.Text == "View All")
            {
                Response.Redirect("http://localhost:51016/ViewAll.aspx");
            }
            else if (DropDownList1.Text == "View Specific")
            {
                Response.Redirect("http://localhost:51016/ViewSpecific.aspx");
            }
            else if (DropDownList1.Text == "Delete")
            {
                Response.Redirect("http://localhost:51016/Delete.aspx");
            }
            else if (DropDownList1.Text == "Edit")
            {
                Response.Redirect("http://localhost:51016/Edit.aspx");
            }
        }
        protected void lb_AddMarks_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:51016/UploadMarks.aspx");
        }

        protected void lb_addrank_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:51016/UploadRank.aspx");
        }
    }
}