using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        int numero = 0;
            
            //O try serve para tratar um erro e não parar a execução do programa
            /*Se ocorrer qualquer erro dentro do bloco try, o sistema interrompe
              a execução do bloco e vai para o catch */
            try
            {
                Console.WriteLine("Digite um número inteiro:");
                numero = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"O número digitado foi: {numero}");
            }
            //Tratando exceção de erro específica de formato
            catch (FormatException)
            {
                Console.WriteLine("Digite um número inteiro");
            }
            catch (OverflowException) 
            {
                Console.WriteLine("O número digitado é maior que o limite.");
            }
            /*Catch é o tratamento do erro, normalmente colocamos as mensagens de acordo
              com o tipo do erro, para melhor compreensão do usuário. */
            catch (Exception erro)
            {
                Console.WriteLine($"Ocorreu um erro genérico: {erro.Message}");
            }
            finally 
            {
                Console.WriteLine($"No bloco finally o programa entra independentemente de exceção.");
            }
 

        Console.ReadLine();
    }
}
