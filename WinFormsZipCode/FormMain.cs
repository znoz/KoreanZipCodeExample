using System.Configuration;
using System.Xml.Serialization;

using WinFormsZipCode.ApiModels;

using static WinFormsZipCode.ApiModels.ApiPostalSearch;

namespace WinFormsZipCode
{
    /// <summary>
    /// 메인 폼
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 폼 로드 이벤트
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
        /// 지번/도로명 입력 텍스트박스의 키 입력 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void textBoxKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 엔터키 입력시
            if (e.KeyChar == (char)Keys.Enter)
            {
                // 우편번호 검색
                await SearchZipCodeAsync();

                // 이벤트 처리 완료
                e.Handled = true;
            }
        }

        /// <summary>
        /// 검색 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            // 우편번호 검색
            await SearchZipCodeAsync();
        }

        /// <summary>
        /// 서비스 키 검증
        /// </summary>
        /// <exception cref="Exception"></exception>
        void ValidationServiceKey()
        {
            var serviceKey = ConfigurationManager.AppSettings["ServiceKey"];

            if (string.IsNullOrWhiteSpace(serviceKey))
            {
                MessageBox.Show("공공 API 서비스 키가 설정되지 않았습니다.\napp.config 파일의 ServiceKey를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                EnableControls(false);
            }
        }

        /// <summary>
        /// 우편번호 검색
        /// </summary>
        async Task SearchZipCodeAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxKeyword.Text)) return;

            EnableControls(false);
            Cursor = Cursors.WaitCursor;
            labelMessage.Text = "";

            // HTTP 클라이언트 생성
            using var client = new HttpClient();

            // 페이지 번호
            if (!int.TryParse(comboBoxPage.Text, out var page))
                page = ApiPostalSearch.DEFAULT_PAGE;

            // 페이지당 출력될 개수
            if (!int.TryParse(comboBoxPageSize.Text, out var countPerPage))
                countPerPage = ApiPostalSearch.DEFAULT_PAGE_SIZE;

            // 요청 생성
            var request = new Request
            {
                SearchKeyword = textBoxKeyword.Text,
                CountPerPage = countPerPage,
                CurrentPage = page
            };

            string url = request.GetApiUrl();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string xml = await response.Content.ReadAsStringAsync();

                ParseXML(xml);
            }

            EnableControls(true);
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// XML 파싱
        /// </summary>
        /// <param name="xml"></param>
        void ParseXML(string xml)
        {
            var serializer = new XmlSerializer(typeof(Response));

            using (TextReader reader = new StringReader(xml))
            {
                var result = serializer.Deserialize(reader) as Response;

                if (result == null)
                {
                    labelMessage.Text = "응답 데이터가 없습니다.";
                }
                else if (result.IsSuccess)
                {
                    dataGridViewAddress.DataSource = result.AddressList;

                    if (result.Header != null)
                    {
                        InitComboBoxPage(result.Header.TotalPage, result.Header.CurrentPage);

                        labelMessage.Text = $"데이터 수: {result.Header.TotalCount:N0}";
                    }
                }
                else
                {
                    labelMessage.Text = result?.Header?.ErrMsg;
                }
            }
        }

        /// <summary>
        /// 컨트롤 활성화 여부 설정
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
        /// 페이지용 콤보 박스 값 설정
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
        /// 페이지 당 최대 개수 콤보 박스 초기화
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
