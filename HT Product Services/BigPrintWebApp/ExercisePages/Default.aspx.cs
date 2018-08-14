using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using HTPSSystem.RSu.BBL;
using HTPSSystem.RSu.Data.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
#endregion
namespace BigPrintWebApp.ExercisePages
{
    public partial class Default : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindCustomerList();                     
            }
        }
        public void BindCustomerList()
        {
            try
            {
                CustomerController sysmgr = new CustomerController();
                List<Customer> info = sysmgr.Customer_List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                CustomerList.DataSource = info;
                CustomerList.DataTextField = nameof(Customer.FullName);
                CustomerList.DataValueField = nameof(Customer.CustomerID);
                CustomerList.DataBind();
                CustomerList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void LookUp_Click(object sender, EventArgs e)
        {
            if (CustomerList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a customer to look up.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {               
                try
                {
                    CustomerController sysmgr = new CustomerController();
                  
                    Customer info = sysmgr.Customer_Find(int.Parse(CustomerList.SelectedValue));
                  
                    if (info == null)
                    {               
                        errormsgs.Add("Customer was not found. Select and try again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindCustomerList();
                    }
                    else
                    {             
                      
                        CustomerID.Text = info.CustomerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Email.Text = info.Email;
                        ContactNumber.Text = info.ContactNumber == null ? "" : info.ContactNumber;
                    }

                }
                catch (Exception ex)
                {
                    errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CustomerList.ClearSelection();
            CustomerID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            ContactNumber.Text = "";

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try
                {
                    Customer newCustomer = new Customer();
                    newCustomer.FirstName = FirstName.Text;
                    newCustomer.LastName = LastName.Text;
                    newCustomer.Email = Email.Text;
                    newCustomer.ContactNumber = ContactNumber.Text == null ? null : ContactNumber.Text;

                    CustomerController sysmgr = new CustomerController();
                    int newcustomerid = sysmgr.Customer_Add(newCustomer);

                    CustomerID.Text = newcustomerid.ToString();
                    BindCustomerList();
                    CustomerList.SelectedValue = CustomerID.Text;

                    errormsgs.Add("Customer has been added.");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

       
    }
}