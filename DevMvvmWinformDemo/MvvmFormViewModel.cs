using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;


namespace DevMvvmWinformDemo
{
    [POCOViewModel()]
    public class MvvmFormViewModel : ViewModelBase
    {
        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                _inputText = value;
                RaisePropertyChanged("InputText");
                OnRichTextChanged();
            }
        }
        private string _richText;

        public string RichText
        {
            get { return _richText; }
            set
            {
                _richText = value;
                RaisePropertiesChanged("RichText");
            }
        }

        //public void OnInputTextChanged()
        //{
        //    this.RaiseCanExecuteChanged(() => CanSubmit());
        //}

        public void OnRichTextChanged()
        {
            this.RaiseCanExecuteChanged(() => Empty());
            this.RaiseCanExecuteChanged(() => Submit());
        }

        public void Submit()
        {
            RichText += InputText;
            OnRichTextChanged();
        }


        public bool CanSubmit()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
            {
                return true;
            }
            return false;
        }

        public void Empty()
        {
            RichText = "";
            InputText = "";
            OnRichTextChanged();
        }

        public bool CanEmpty()
        {
            if (!string.IsNullOrWhiteSpace(RichText))
            {
                return true;
            }
            return false;
        }
    }
}
