namespace App.EndPoint.ShopUi.Services
{
    public interface IConverting
    {
        DateTime ConvertShamsiToMiladi(string Date);
        string ConvertMiladiToShamsi(DateTime Date, string Format);
    }
}
