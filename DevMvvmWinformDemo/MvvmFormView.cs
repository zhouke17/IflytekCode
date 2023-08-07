using System.Windows.Forms;

namespace DevMvvmWinformDemo
{
    public partial class MvvmFormView : Form
    {
        public MvvmFormView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MvvmFormViewModel>();


            fluent.BindCommand<MvvmFormViewModel>(btn_submit, (x, y) => x.Submit());
            fluent.BindCommand<MvvmFormViewModel>(btn_empty, (x, y) => x.Empty());

            fluent.SetTrigger((x) => x.InputText, (x) =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    //this.btn_submit.Enabled = false;
                }
                else
                {
                    //this.btn_submit.Enabled = true;
                }
            });

            fluent.SetBinding(txt_input, x => x.Text, x => x.InputText);
            fluent.SetBinding(richtxt_show, x => x.Text, x => x.RichText);


        }
    }
}
