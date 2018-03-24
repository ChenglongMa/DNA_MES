using DnaMesUiBll.BasicInfo;

namespace DnaMesUi.Templetes
{
    public partial class WithTreeForm : BaseForm
    {
        public WithTreeForm()
        {
            InitializeComponent();
            _bll.BuildTree(ref uTree,imageList1.Images);
        }

        private readonly ProjectMgtBll _bll=new ProjectMgtBll();

    }
}