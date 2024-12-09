using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.MyComponent;
using BookStore.Views.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.Forms
{
    public partial class createOrders : UserControl
    {
        private CancellationTokenSource _cancellationTokenSource;

        public createOrders()
        {
            InitializeComponent();
        }
        private readonly ListOrder ListOrder;
        public createOrders(ListOrder ListOrder) : this()
        {
            this.ListOrder = ListOrder;
            AddNewOrderButton();
        }



        // Tạo mới button và tab
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            AddNewOrderButton();
        }

        private void AddNewOrderButton()
        {
            maxIndex++;
            // Tạo button mới
            var newButton = CreateButtonOrder();
            flowLayoutPanel1.Controls.Add(newButton);

            // Đặt vị trí button mới trước phần tử cuối
            if (flowLayoutPanel1.Controls.Count > 1)
            {
                flowLayoutPanel1.Controls.SetChildIndex(newButton, flowLayoutPanel1.Controls.Count - 2);
            }

            // Tạo tab mới
            var newTabPage = CreateTabPage(newButton);
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;

            // Đổi màu nút khi được chọn
            ChangeButtonColors(newButton);
        }
        private int maxIndex = 0;  // Khởi tạo maxIndex


        private buttonOrder CreateButtonOrder()
        {
            var newButton = new buttonOrder
            {
                BackColor = Color.Transparent,
                BorderRadius = 10,
                FillColor = SystemColors.Control,
                Font = new Font("Arial", 9.75F, FontStyle.Bold),
                ForeColor = Color.Black,
                HoverState = new() // Khởi tạo HoverState
                {
                    FillColor = SystemColors.Control,
                },
                Image = Properties.Resources.close__1_,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(12, 12),
                Text = "Hóa đơn " + (maxIndex),
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(5, 0),
                Size = new Size(129, 70),
                Tag = maxIndex
            };

            // Gán sự kiện
            newButton.MouseClick += NewButton_MouseClick;
            newButton.Click_Image += NewButton_delete;

            return newButton;
        }

        private TabPage CreateTabPage(buttonOrder button)
        {
            var newTabPage = new TabPage("Tab " + (maxIndex))
            {
                Tag = maxIndex,

            };

            if (this.ListOrder != null)
            {
                var createOrder = new CreateOrder(this.ListOrder, this, button)
                {
                    Dock = DockStyle.Fill
                };
                newTabPage.Controls.Add(createOrder);
            }




            return newTabPage;
        }

        private void NewButton_MouseClick(object sender, EventArgs e)
        {
            buttonOrder clickedButton = (buttonOrder)sender;
            ChangeButtonColors(clickedButton);
            int tabIndex = (int)clickedButton.Tag;  // Lấy tag của button (tương ứng với tab)

            // Kiểm tra tab tương ứng
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if ((int)tab.Tag == tabIndex)
                {
                    // Chọn tab tương ứng
                    tabControl1.SelectedTab = tab;
                    break;
                }
            }
        }

        private void NewButton_delete(object sender, EventArgs e)
        {
            buttonOrder buttonToRemove = (buttonOrder)sender;
            deleteOrderTemp(buttonToRemove);
        }


        public void deleteOrderTemp(buttonOrder buttonToRemove)
        {
            if (buttonToRemove != null)
            {
                // Xóa button khỏi FlowLayoutPanel
                flowLayoutPanel1.Controls.Remove(buttonToRemove);
                int tabIndex = (int)buttonToRemove.Tag;  // Lấy tag của button (tương ứng với tab)
                
                // Kiểm tra tab tương ứng
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if ((int)tab.Tag == tabIndex)
                    {
                        if (tabControl1.SelectedTab == tab)
                        {
                            tabControl1.SelectedIndex = 0;
                            int newtagIndex = (int)tabControl1.TabPages[0].Tag;
                            foreach (var btn in flowLayoutPanel1.Controls.OfType<buttonOrder>())
                            {
                                if ((int)btn.Tag == newtagIndex)
                                {btn.FillColor = SystemColors.Control;
                                    break;
                                }
                                
                            }
                            // Xóa tab khỏi TabControl
                            tabControl1.TabPages.Remove(tab);
                            break;
                        }
                    }
                }

                if (flowLayoutPanel1.Controls.Count == 1)
                {
                    AddNewOrderButton();
                }
            }
        }


        private void ChangeButtonColors(buttonOrder clickedButton)
        {
            foreach (var btn in flowLayoutPanel1.Controls.OfType<buttonOrder>())
            {
                btn.FillColor = btn == clickedButton ? SystemColors.Control : Color.Silver;
            }
        }

        // Xử lý tìm kiếm sản phẩm
        private async void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                await Task.Delay(500, cancellationToken);
                string input = guna2TextBox1.Text;

                var products = ProductDAO.SearchProducts(input);
                SetProductData(products);
            }
            catch (TaskCanceledException)
            {
                // Task bị hủy, không làm gì
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void SetProductData(List<ProductViewModel> products)
        {
            guna2DataGridView1.Rows.Clear();

            foreach (var product in products)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();

                guna2DataGridView1.Rows[rowIndex].Cells["img"].Value = GetImageFromPath(product.UrlImg);
                guna2DataGridView1.Rows[rowIndex].Cells["productID"].Value = product.ProductID;
                guna2DataGridView1.Rows[rowIndex].Cells["ProductName"].Value = product.Name;
                guna2DataGridView1.Rows[rowIndex].Cells["price"].Value = product.Price;
                guna2DataGridView1.Rows[rowIndex].Cells["stock"].Value = product.StockLevel;
                guna2DataGridView1.Rows[rowIndex].Cells["categories"].Value = product.CategoryName;
            }

            guna2DataGridView1.Height = 50 * products.Count;
        }

        private Image GetImageFromPath(string relativePath)
        {
            string fullPath = Path.Combine(Application.StartupPath, relativePath);
            if (File.Exists(fullPath))
            {
                return Image.FromFile(fullPath);
            }
            return null; // Hoặc đặt hình ảnh mặc định
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                var selectedProduct = new ProductViewModel
                {
                    ProductID = Convert.ToInt32(selectedRow.Cells["productID"].Value),
                    Name = selectedRow.Cells["ProductName"].Value?.ToString(),
                    Price = Convert.ToDecimal(selectedRow.Cells["price"].Value),
                    StockLevel = Convert.ToInt32(selectedRow.Cells["stock"].Value),
                    CategoryName = selectedRow.Cells["categories"].Value?.ToString()
                };

                var currentTab = tabControl1.SelectedTab;
                var createOrder = currentTab.Controls.OfType<CreateOrder>().FirstOrDefault();

                createOrder?.setItemOrder(selectedProduct);

                guna2DataGridView1.Rows.Clear();
                guna2DataGridView1.Height = 0;
            }
        }
        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            // Nếu DataGridView không được focus, ẩn nó
            if (!guna2DataGridView1.Focused)
            {
                guna2DataGridView1.Visible = false;
            }
        }

        private void guna2DataGridView1_Leave(object sender, EventArgs e)
        {
            if (!guna2TextBox1.Focused)
            {
                guna2DataGridView1.Visible = false;
            }
        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = true; // Hiển thị DataGridView
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                // Loại bỏ UserControl con khỏi Form cha
                this.Parent.Controls.Remove(this);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
