using ExpressionTree_Calculator;
namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClickedUpdateLabel(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (Output.Text == "0")
                    Output.Text = button.Text;
                else
                    Output.Text += button.Text;
            }
        }

        private void OnButtonClickedEqualTo(object sender, EventArgs e)
        {
            var equation = Output.Text;
            double result = 0;
            var queue = StringParser.Parse(equation);
            var tree = Expression.GenerateExpressionTree(queue);
            result = tree.Evaluate();
            Output.Text = result.ToString();
        }

        //private void OnButtonClickedEqualTo(object sender, EventArgs e) 
        //{
        //    var equation = Output.Text;
        //    bool equationConstructed = false;
        //    double result = 0;
        //    char sign = 'n';
        //    int numOne = 0;
        //    int numTwo = 0;
        //    int i = 0;            
        //    try
        //    {
        //        do
        //        {
        //            if (int.TryParse(equation[i].ToString(), out int temp))
        //            {
        //                sign = equation[i];
        //                equationConstructed = true;
        //            }

        //            numOne = int.Parse(equation.Substring(0, i + 1));
        //            numTwo = int.Parse(equation.Substring(i + 1));
        //        } while (!equationConstructed || i > equation.Length);

        //        result = sign switch
        //        {
        //            '+' => numOne + numTwo,
        //            '-' => numOne - numTwo,
        //            '/' => numOne / numTwo,
        //            '*' => (double)(numOne * numTwo),
        //            _ => throw new FormatException(),
        //        };
        //    }
        //    catch(Exception ex) 
        //    {
        //        Output.Text = ex.ToString();
        //    }
        //}

        private void OnButtonClear(object sender, EventArgs e)
        {
            Output.Text = "0";
        }
    }
}