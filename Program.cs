using System;

class Program
{
    static void Main()
    {
        // Cria uma instância da televisão
        Televisao tv = new Televisao(55f);
        
        // Exibe uma mensagem de boas-vindas
        Console.WriteLine("Bem-vindo ao controle remoto da sua TV! Digite 'ajuda' para ver as opções.");

        // Loop principal para manter a interação
        while (true)
        {
            Console.Write("\nDigite um comando: ");
            string comando = Console.ReadLine()?.ToLower(); // Lê o comando e converte para minúsculas

            if (string.IsNullOrWhiteSpace(comando))
            {
                continue; // Ignora entradas vazias
            }

            // Estrutura para processar os comandos
            switch (comando)
            {
                case "ligar":
                    if (!tv.Estado) tv.Ligar();
                    else Console.WriteLine("A TV já está ligada.");
                    break;
                case "desligar":
                    if (tv.Estado) tv.Desligar();
                    else Console.WriteLine("A TV já está desligada.");
                    break;
                case "aumentar volume":
                case "v+":
                    if (tv.Estado) tv.AumentarVolume();
                    else Console.WriteLine("A TV está desligada. Não é possível ajustar o volume.");
                    break;
                case "diminuir volume":
                case "v-":
                    if (tv.Estado) tv.DiminuirVolume();
                    else Console.WriteLine("A TV está desligada. Não é possível ajustar o volume.");
                    break;
                case "mudo":
                    if (tv.Estado) tv.AtivarMudo();
                    else Console.WriteLine("A TV está desligada. Não é possível ativar o mudo.");
                    break;
                case "avancar canal":
                case "c+":
                    if (tv.Estado) tv.AvancarCanal();
                    else Console.WriteLine("A TV está desligada. Não é possível avançar o canal.");
                    break;
                case "voltar canal":
                case "c-":
                    if (tv.Estado) tv.VoltarCanal();
                    else Console.WriteLine("A TV está desligada. Não é possível voltar o canal.");
                    break;
                case "canal":
                    TrocarCanal(tv);
                    break;
                case "status":
                    ExibirStatus(tv);
                    break;
                case "ajuda":
                    ExibirAjuda();
                    break;
                case "sair":
                    Console.WriteLine("Saindo do controle remoto. Até a próxima!");
                    return; // Encerra o programa
                default:
                    Console.WriteLine("Comando inválido. Digite 'ajuda' para ver a lista de comandos.");
                    break;
            }
        }
    }
    
    // Método para tratar a troca de canal
    private static void TrocarCanal(Televisao tv)
    {
        if (!tv.Estado)
        {
            Console.WriteLine("A TV está desligada. Não é possível trocar o canal.");
            return;
        }

        Console.Write("Digite o número do canal: ");
        if (int.TryParse(Console.ReadLine(), out int numeroCanal))
        {
            tv.TrocarCanal(numeroCanal);
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        }
    }

    // Método para exibir o status atual da TV
    private static void ExibirStatus(Televisao tv)
    {
        Console.WriteLine("--- Status da TV ---");
        Console.WriteLine($"Estado: {(tv.Estado ? "Ligada" : "Desligada")}");
        Console.WriteLine($"Volume: {tv.Volume}");
        Console.WriteLine($"Canal: {tv.Canal}");
        Console.WriteLine("--------------------");
    }

    // Método para exibir o menu de ajuda
    private static void ExibirAjuda()
    {
        Console.WriteLine("--- Comandos disponíveis ---");
        Console.WriteLine("'ligar'             - Liga a TV.");
        Console.WriteLine("'desligar'          - Desliga a TV.");
        Console.WriteLine("'aumentar volume' ou 'v+' - Aumenta o volume.");
        Console.WriteLine("'diminuir volume' ou 'v-' - Diminui o volume.");
        Console.WriteLine("'mudo'              - Ativa/desativa o mudo.");
        Console.WriteLine("'avancar canal' ou 'c+'   - Vai para o próximo canal.");
        Console.WriteLine("'voltar canal' ou 'c-'    - Volta para o canal anterior.");
        Console.WriteLine("'canal'             - Troca para um canal específico.");
        Console.WriteLine("'status'            - Exibe o status atual da TV (ligada/desligada, volume, canal).");
        Console.WriteLine("'ajuda'             - Mostra este menu de ajuda.");
        Console.WriteLine("'sair'              - Encerra o programa.");
        Console.WriteLine("----------------------------");
    }
    
}