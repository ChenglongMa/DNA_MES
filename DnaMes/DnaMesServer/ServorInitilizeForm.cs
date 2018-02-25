using System;
using System.Windows.Forms;
using DnaLib.Helper;

namespace DnaMesServer
{
    public partial class ServorInitilizeForm : Form
    {
        //MesDbInitBsl bslMesDbInit = new MesDbInitBsl("MES");

        public ServorInitilizeForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDBInitial_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.ShowQuestion("该操作将删除现有的数据，是否继续？"))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    Application.DoEvents();
                    //bslMesDbInit.InitialMESDatabase();                    
                    MessageBoxHelper.ShowInformationOk("操作结束！");
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBoxHelper.ShowError(ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnBackupRestore_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (MessageBoxHelper.ShowInformation("是否删除之前的设备信息"))
            {
                Application.DoEvents();
            }

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }

        private void btnUpdateDataBase_Click(object sender, EventArgs e)
        {
            //bslMesDbInit.UpdateMESDatabase();           
        }
    }
}