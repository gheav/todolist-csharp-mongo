using csharp_mongo.Core;
using csharp_mongo.Models;
using csharp_mongo.Repository;
using System;
using System.Windows.Forms;

namespace csharp_mongo.Views
{
    public partial class Welcome : Form
    {
        private UsersRepository usersRepository;

        public Welcome()
        {
            usersRepository = new UsersRepository();
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(textBoxFullname.Text == string.Empty || textBoxEmail.Text == string.Empty)
            {
                MessageBox.Show("Let me know you, please write your name and email", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(Helper.IsValidEmail(textBoxEmail.Text) == false)
            {
                MessageBox.Show("Please correct your email", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullname = textBoxFullname.Text;
            string email    = textBoxEmail.Text;
            Users users = new Users
            {
                _id          = Helper.GetUUID(),
                fullname    = fullname,
                email       = email
            };
            var user        = usersRepository.GetUser(email);

            if (user == null)
            {
                usersRepository.InsertUser(users);
            }
            Visible = false;
            TodoList todoListForm = new TodoList(email);
            todoListForm.Show();
        }
    }
}
