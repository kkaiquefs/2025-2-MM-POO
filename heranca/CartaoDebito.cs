public class CartaoDebito
{

    public CartaoDebito()
    {
        Bandeira = BandeiraCartao.Mastercard;

    }


    public string Numero { get; set; }
    
    public BandeiraCartao Bandeira { get; set; }

}

public enum BandeiraCartao{
    Visa,
    Mastercard,
    Amex,
    Elo
}