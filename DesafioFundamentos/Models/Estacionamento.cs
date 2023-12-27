

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0; 
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
             try
             {
                // Pede para o usuário digitar a placa e armazena na variável placa
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();
                placa = placa.ToUpper();

                // Checa se a placa já está na lista veiculos
                if (veiculos.Contains(placa))
                {
                    Console.WriteLine("Veículo já cadastrado. Não é possível cadastrar novamente.");
                }
                else
                {
                     //cadastra o novo veículo na lista veiculos
                     veiculos.Add(placa);
                    // guarda a data em que foi feita a operação
                    DateTime dataInclusao = DateTime.Now;

                    // declara a placa recém cadastrada, data e horário de cadastro
                    Console.WriteLine($"Veículo {placa} cadastrado às {dataInclusao.ToString("dd/MM/yyyy HH:mm")}");
                }
             }

            // Trata exceção
            catch (Exception ex)
             {
                Console.WriteLine($"Ocorreu um erro. {ex.Message}");
             }

            
        }   

        public void RemoverVeiculo()
        {
            try
            {
             
                //Pede para o usuário digitar a placa e armazena na variável placa
                Console.WriteLine("Digite a placa do veículo a ser removido:");
                string placa = Console.ReadLine();
                placa = placa.ToUpper();
                int horas = 0;
            

                // Verifica se o veículo existe
                if (veiculos.Contains(placa))
                {
                
                    // guarda a data em que foi feita a operação
                    DateTime dataRemocao = DateTime.Now;

                    // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado e atualiza a variável horas com o valor
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    horas = int.Parse(Console.ReadLine());

                    // Calcula o valor total a ser pago
                    decimal valorTotal = precoInicial + (precoPorHora * horas); 

                    // Remover a placa digitada da lista de veículos e guarda na variável veiculoRemovido
                     veiculos.Remove(placa);

                
                    // Mostra no console o resultado da remoção
                    Console.WriteLine($"O veículo de placa {placa.ToUpper()} foi removido às {dataRemocao.ToString("HH:mm")} de {dataRemocao.ToString("dd/MM/yyyy")}.");
                    Console.WriteLine($"O preço total a ser pago é de:  {valorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }

            // Trata exceção
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro. {ex.Message}");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                 Console.WriteLine("Os veículos estacionados são:");
               // Exibe todos os veículos cadastrados
                 foreach (var carro in veiculos)
                 {
                    Console.WriteLine(carro.ToUpper());
                 }
            }
             else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
