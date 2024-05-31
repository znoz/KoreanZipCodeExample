using System.Configuration;
using System.Xml.Serialization;

using WinFormsZipCode.ApiModels;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WinFormsZipCode.ApiModels.ApiPostalSearch;

namespace WinFormsZipCode
{
    /// <summary>
    /// ���� ��
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// ������
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �� �ε� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty;

            InitComboBoxPageSize();

            ValidationServiceKey();
        }

        /// <summary>
        /// ����/���θ� �Է� �ؽ�Ʈ�ڽ��� Ű �Է� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void textBoxKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ����Ű �Է½�
            if (e.KeyChar == (char)Keys.Enter)
            {
                // �����ȣ �˻�
                await SearchZipCodeAsync();

                // �̺�Ʈ ó�� �Ϸ�
                e.Handled = true;
            }
        }

        /// <summary>
        /// �˻� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            // �����ȣ �˻�
            await SearchZipCodeAsync();
        }

        /// <summary>
        /// ���� Ű ����
        /// </summary>
        /// <exception cref="Exception"></exception>
        void ValidationServiceKey()
        {
            var serviceKey = ConfigurationManager.AppSettings["ServiceKey"];

            if (string.IsNullOrWhiteSpace(serviceKey))
            {
                MessageBox.Show("���� API ���� Ű�� �������� �ʾҽ��ϴ�.\napp.config ������ ServiceKey�� Ȯ�����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                EnableControls(false);
            }
        }

        /// <summary>
        /// �����ȣ �˻�
        /// </summary>
        async Task SearchZipCodeAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxKeyword.Text)) return;

            try
            {
                EnableControls(false);
                Cursor = Cursors.WaitCursor;
                labelMessage.Text = "";

                // ��û ����
                var request = CreateRequest();

                // API URL
                string url = request.GetApiUrl();

                // HTTP Ŭ���̾�Ʈ ����
                using var client = new HttpClient();

                // API GET ȣ��
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string xml = await response.Content.ReadAsStringAsync();

                    LoadData(xml);
                }

                EnableControls(true);
                Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// ��û ����
        /// </summary>
        /// <returns></returns>
        Request CreateRequest()
        {
            // ������ ��ȣ
            if (!int.TryParse(comboBoxPage.Text, out var page))
                page = ApiPostalSearch.DEFAULT_PAGE;

            // �������� ��µ� ����
            if (!int.TryParse(comboBoxPageSize.Text, out var countPerPage))
                countPerPage = ApiPostalSearch.DEFAULT_PAGE_SIZE;

            return new Request
            {
                SearchKeyword = textBoxKeyword.Text,
                CountPerPage = countPerPage,
                CurrentPage = page
            };
        }

        /// <summary>
        /// XML ������ �о �׸��忡 ���ε�
        /// </summary>
        /// <param name="xml"></param>
        void LoadData(string xml)
        {
            var serializer = new XmlSerializer(typeof(Response));

            using (TextReader reader = new StringReader(xml))
            {
                var result = serializer.Deserialize(reader) as Response;

                if (result == null) throw new Exception("���� �����Ͱ� �����ϴ�.");

                if (!result.IsSuccess) throw new Exception(result.Header?.ErrMsg);

                dataGridViewAddress.DataSource = result.AddressList;

                if (result.Header != null)
                {
                    InitComboBoxPage(result.Header.TotalPage, result.Header.CurrentPage);

                    labelMessage.Text = $"������ ��: {result.Header.TotalCount:N0}";
                }
            }
        }

        /// <summary>
        /// ��Ʈ�� Ȱ��ȭ ���� ����
        /// </summary>
        /// <param name="enable"></param>
        void EnableControls(bool enable)
        {
            textBoxKeyword.Enabled = enable;
            buttonSearch.Enabled = enable;
            comboBoxPage.Enabled = enable;
            comboBoxPageSize.Enabled = enable;
        }

        /// <summary>
        /// �������� �޺� �ڽ� �� ����
        /// </summary>
        /// <param name="totalPage"></param>
        /// <param name="currentPage"></param>
        void InitComboBoxPage(int totalPage, int currentPage)
        {
            comboBoxPage.Items.Clear();

            for (int i = 1; i <= totalPage; i++)
            {
                comboBoxPage.Items.Add(i);
            }

            if (comboBoxPage.Items.Count >= currentPage)
            {
                comboBoxPage.SelectedIndex = currentPage - 1;
            }
        }

        /// <summary>
        /// ������ �� �ִ� ���� �޺� �ڽ� �ʱ�ȭ
        /// </summary>
        void InitComboBoxPageSize()
        {
            comboBoxPageSize.Items.Clear();

            for (int i = 10; i <= Request.MAX_PAGE_SIZE; i += 10)
            {
                comboBoxPageSize.Items.Add(i);
            }

            comboBoxPageSize.SelectedIndex = 0;
        }
    }
}
