using System;

public class Televisao
{
    private const int VOLUME_MAXIMO = 100;
    private const int VOLUME_MINIMO = 0;
    private const int CANAL_MAXIMO = 540;
    private const int CANAL_MINIMO = 0;

    private int _canalAtual;
    private int _ultimoCanalAssistido;
    private int _volumeAtual;
    private bool _mudoAtivo;

    public Televisao(float tamanho)
    {
        Tamanho = tamanho;
        Estado = false;
        _volumeAtual = 25;  // volume inicial default
        _canalAtual = CANAL_MINIMO;
        _ultimoCanalAssistido = CANAL_MINIMO;
        _mudoAtivo = false;
    }

    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public bool Estado { get; private set; }

    public int Volume
    {
        get => _mudoAtivo ? 0 : _volumeAtual;
        private set
        {
            if (value < VOLUME_MINIMO)
                _volumeAtual = VOLUME_MINIMO;
            else if (value > VOLUME_MAXIMO)
                _volumeAtual = VOLUME_MAXIMO;
            else
                _volumeAtual = value;

            if (_mudoAtivo && _volumeAtual > 0)
                _mudoAtivo = false; // desliga mudo ao ajustar volume
        }
    }

    public int Canal
    {
        get => _canalAtual;
        private set
        {
            if (value < CANAL_MINIMO || value > CANAL_MAXIMO)
                Console.WriteLine($"Canal inválido. Informe um canal entre {CANAL_MINIMO} e {CANAL_MAXIMO}.");
            else
            {
                _canalAtual = value;
                _ultimoCanalAssistido = value;
            }
        }
    }

    // Liga a TV e seleciona o último canal assistido
    public void Ligar()
    {
        Estado = true;
        Canal = _ultimoCanalAssistido;
        Console.WriteLine($"TV ligada no canal {_canalAtual}");
    }

    // Desliga a TV
    public void Desligar()
    {
        Estado = false;
        Console.WriteLine("TV desligada.");
    }

    // Aumenta volume em 1, respeitando o máximo
    public void AumentarVolume()
    {
        if (Volume < VOLUME_MAXIMO)
        {
            Volume++;
            Console.WriteLine($"Volume aumentado para {Volume}");
        }
        else
        {
            Console.WriteLine("Volume já está no máximo.");
        }
    }

    // Reduz volume em 1, respeitando o mínimo
    public void DiminuirVolume()
    {
        if (Volume > VOLUME_MINIMO)
        {
            Volume--;
            Console.WriteLine($"Volume reduzido para {Volume}");
        }
        else
        {
            Console.WriteLine("Volume já está no mínimo.");
        }
    }

    // Ativa ou desativa o mudo
    public void AtivarMudo()
    {
        if (!_mudoAtivo)
        {
            _mudoAtivo = true;
            Console.WriteLine("Mudo ativado.");
        }
        else
        {
            _mudoAtivo = false;
            Console.WriteLine($"Mudo desativado. Volume atual: {Volume}");
        }
    }

    // Passa para o próximo canal, respeitando o limite
    public void AvancarCanal()
    {
        if (Canal < CANAL_MAXIMO)
        {
            Canal++;
            Console.WriteLine($"Canal avançado para {Canal}");
        }
        else
        {
            Console.WriteLine("Já está no canal máximo.");
        }
    }

    // Passa para o canal anterior, respeitando o limite
    public void VoltarCanal()
    {
        if (Canal > CANAL_MINIMO)
        {
            Canal--;
            Console.WriteLine($"Canal voltado para {Canal}");
        }
        else
        {
            Console.WriteLine("Já está no canal mínimo.");
        }
    }

    // Troca direto para o canal informado
    public void TrocarCanal(int numeroCanal)
    {
        if (numeroCanal < CANAL_MINIMO || numeroCanal > CANAL_MAXIMO)
        {
            Console.WriteLine($"Canal inválido. Informe um canal entre {CANAL_MINIMO} e {CANAL_MAXIMO}.");
            return;
        }
        Canal = numeroCanal;
        Console.WriteLine($"Canal trocado para {Canal}");
    }
}
