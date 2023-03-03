using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using OpenQA.Selenium.Support.UI;

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//1- Entrar no site dos correios
driver.Navigate().GoToUrl("https://www.correios.com.br/");


//2- Procure pelo CEP 80700000
IWebElement cepInput1 = driver.FindElement(By.Name("relaxation"));
cepInput1.SendKeys("80700000");
cepInput1.SendKeys(Keys.Return);


//3- Confirmar que o CEP não existe
IWebElement mensagem = driver.FindElement(By.ClassName("mensagem-erro"));
    if (mensagem.Text.Contains("Dados não encontrado")) {
        Console.WriteLine("CEP não existe!");
    } else {
        Console.WriteLine("CEP existe!");
    }


//4- Voltar a tela inicial
driver.Navigate().GoToUrl("https://www.correios.com.br/");


//5- Procure pelo CEP 01013-001
IWebElement cepInput2 = driver.FindElement(By.Name("relaxation"));
cepInput1.SendKeys("01013-001");
cepInput1.SendKeys(Keys.Return);


//6- Confirmar que o resultado seja em “Rua Quinze de Novembro - lado ímpar”
 IWebElement cepResult = driver.FindElement(By.CssSelector(".respostadestaque"));
    if (cepResult.Text == "Rua Quinze de Novembro - lado ímpar") {
        Console.WriteLine("CEP correto"); //.aberto
    } else {
        Console.WriteLine("CEP incorreto");
    }

//7- Voltar a tela inicial;
driver.Navigate().GoToUrl("https://www.correios.com.br/");


//8- Procurar no rastreamento de código o número “SS987654321BR”
 IWebElement rastreamentoInput = driver.FindElement(By.Id("objetos"));
    rastreamentoInput.SendKeys("SS987654321BR");
    rastreamentoInput.SendKeys(Keys.Return);

IWebElement captcha = driver.FindElement(By.Id("captcha_image"));
string valor = captcha.Text;

IWebElement campo = driver.FindElement(By.Id("captcha"));
campo.SendKeys(valor);
campo.SendKeys(Keys.Return);


//9- Confirmar que o código não está correto;
 IWebElement rastreamentoError = driver.FindElement(By.CssSelector(".error"));
    if (rastreamentoError.Text == "Não há dados para serem exibidos.") {
        Console.WriteLine("Código de rastreamento incorreto");
    } else {
        Console.WriteLine("Código de rastreamento correto");
    }

//10- Fechar o browser;
driver.Quit();