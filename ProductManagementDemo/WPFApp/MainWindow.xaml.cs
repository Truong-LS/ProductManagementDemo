using BusinessObjects;
using Repositories_Repositories;
using Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public MainWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            categoryService = new CategoryService();
        }
        public void LoadCategoryList()
        {
            try
            {
                var catList = categoryService.GetCategories();
                cboCategory.ItemsSource = catList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }
        public void LoadProductList()
        {
            try
            {
                var productList = productService.GetProducts();
                dgData.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");
            }
            finally
            {
                resetInput();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtProductName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                productService.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            DataGridRow row =

            (DataGridRow)dataGrid.ItemContainerGenerator

            .ContainerFromIndex(dataGrid.SelectedIndex);

            DataGridCell RowColumn =

            dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

            string id = ((TextBlock)RowColumn.Content).Text;

            Product product = productService.GetProductById(Int32.Parse(id));

            txtProductID.Text = product.ProductId.ToString();

            txtProductName.Text = product.ProductName;

            txtPrice.Text = product.UnitPrice.ToString();

            txtUnitsInStock.Text = product.UnitsInStock.ToString();

            cboCategory.SelectedValue = product.CategoryId;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = Int32.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    productService.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally

            {
                LoadProductList();
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductId = Int32.Parse(txtProductID.Text);
            product.ProductName = txtProductName.Text;
            product.UnitPrice = Decimal.Parse(txtPrice.Text);
            product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
            product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
            productService.DeleteProduct(product);
        }
        private void resetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }
    }
}