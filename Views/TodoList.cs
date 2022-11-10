using System;
using System.Diagnostics;
using System.Windows.Forms;
using csharp_mongo.Models;
using csharp_mongo.Repository;

namespace csharp_mongo
{
    public partial class TodoList : Form
    {
        UsersRepository usersRepository;
        TodosRepository todoRepository;
        public TodoList(string email)
        {
            usersRepository = new UsersRepository();
            todoRepository = new TodosRepository();
            InitializeComponent();
            var user = usersRepository.GetUser(email);
            labelFullname.Text = user.fullname;
            textBoxEmail.Text = user.email;
            StartTimer();
            loadTodo();
        }
        Timer t = null;
        private void StartTimer()
        {
            t           = new Timer();
            t.Interval  = 1000;
            t.Tick      += new EventHandler(t_Tick);
            t.Enabled   = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }
        private void saveTodo()
        {
            string[] action = { textBoxTodo.Text };
            Todos todo = new Todos()
            {
                email   = textBoxEmail.Text,
                actions = action
            };
            todoRepository.InsertTodo(todo);
            textBoxTodo.Text =string.Empty ;
            textBoxTodo.Focus();
            loadTodo();
        }
        private void loadTodo()
        {
            listViewActions.Items.Clear();
            string email    = textBoxEmail.Text;
            var actions     = todoRepository.GetActions(email);
            foreach (var action in actions)
            {
                ListViewItem act = new ListViewItem(action.actions);
                listViewActions.Items.Add(act);
            }
        }

        private void textBoxTodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            saveTodo();
        }
    }
}
