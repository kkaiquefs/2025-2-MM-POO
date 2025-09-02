public class Televisao
{

    public Televisao(float tamanho)
    {
        Tamanho = tamanho;
    }

    public float Tamanho {get;}
    public int Resolucao {get; set;}
    public int Volume {get; set;}
    public int Canal {get; set;}
    public bool Estado {get; set;}

    public void AumentarVolume(){

        Volume = Volume + 1;

    }

    public void DiminuirVolume(){

        Volume = Volume - 1;

    }

}