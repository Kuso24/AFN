//(a + b) * a (a + b)

using AFN;

string cadena = "aabaaabaaab";
char[] chars = cadena.ToCharArray();

/*
 * La función "contador_de_b", se encarga de contar
 * el número de b's en la cadena, tomando como datos
 * un contador, que determina cual es el caracter actual
 * que esta ingresando en el automata finito.
 * Tambien se toma como dato a "vector_cadena", que es un
 * arreglo con todos los caracteres de la cadena
*/
bool contador_de_b(int contador_vector, char[] vector_cadena)
{
    int cont = 0;
    for (int i = contador_vector; i < vector_cadena.Length; i++)
    {
        if (vector_cadena[i] == 'b')
            cont++;
    }
    if (cont >= 2)
        return true;
    else
        return false;
}

if (automata_finito())
    Console.WriteLine("Es válido");
else
    Console.WriteLine("No es válido");

bool automata_finito()
{
    estados status = estados.q0;
    Console.WriteLine("q0");
    /*
     * La variable "contador", es la que indicara el número de
     * caracter que esta ingresando en el automata
    */
    int contador = 0;
    foreach(char x in cadena)
    {
        switch (status)
        {
            case estados.q0:
                /*
                 * Con el if(contador_de_b(contador, chars)), 
                 * determinamos si hay más de 1 b, si el resultado es
                 * "true", entonces eso significa que se entro al ciclo q1 [(a+b)*]
                 * en cambio, si el resultado de la función es "false", eso significa
                 * que ya solo queda la parte final del automata q2->q3->q4 [a (a + b)]
                 */
                if (contador_de_b(contador, chars))
                {
                    if(x == 'a')
                    {
                        status = estados.q1;
                        Console.WriteLine("q1");
                        contador++;
                        break;
                    }
                }
                else if(x == 'a')
                {
                    status = estados.q2;
                    Console.WriteLine("q2");
                    contador++;
                    break;
                }
                break;

            case estados.q1:
                if (x == 'a')
                {
                    status = estados.q1;
                    Console.WriteLine("q1");
                    contador++;
                    break;
                }
                else if(x == 'b')
                {
                    status = estados.q0;
                    Console.WriteLine("q0");
                    contador++;
                    break;
                }
                break;

            case estados.q2:
                if (x == 'a')
                {
                    status = estados.q3;
                    Console.WriteLine("q3");
                    contador++;
                    break;
                }
                break;

            case estados.q3:
                if (x == 'a')
                {
                    status = estados.q3;
                    Console.WriteLine("q3");
                    contador++;
                    break;
                }
                else if (x == 'b')
                {
                    status = estados.q4;
                    Console.WriteLine("q4");
                    contador++;
                    break;
                }
                break;
        }

    }
    return (estados.q4 == status);

}