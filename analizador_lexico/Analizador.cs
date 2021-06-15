using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_calc
{
    class Analizador
    {
        ArrayList tokens;
        ArrayList tipos;


        ArrayList Lista_Operaciones;

        static private List<Token> listaTokens; //Declaro mi listado tipo la clase que creé
        

        private String retorno;
        public int estado_token;

        //errores tokens
        static private List<ErroresToken> listaErrores;

        public Analizador()
        {
            //listado de tokens
            listaTokens = new List<Token>();
            tokens = new ArrayList();
            tipos = new ArrayList();

            tokens.Add("Resultado");  //0
            tokens.Add("Graficar"); //1
            tokens.Add("Node"); //2

            tipos.Add("Valor");
            tipos.Add("Operador");
            tipos.Add("IZQ");
            tipos.Add("DER");

            Lista_Operaciones = new ArrayList();
         

            //errores toks
            listaErrores = new List<ErroresToken>();

        }

        public void addToken(String lexema, String idToken, int linea, int columna, int indice)
        {
            //recibo los parametros y voy guardando en listaTokens
            Token nuevo = new Token(lexema, idToken, linea, columna, indice ); //llamo mi listado y le voy mandando los datos recibidos 
            listaTokens.Add(nuevo); //y voy agregando en mi listado
        }

        //por si se encuentra algun error case 2
        public void addError(String lexema, String idToken, int linea, int columna)
        {
            ErroresToken errtok = new ErroresToken(lexema, idToken, linea, columna);
            listaErrores.Add(errtok);
        }

        public void Analizador_cadena(String entrada)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            Char c;
            //Recibo el texto con la variable entrada
            entrada = entrada + " "; //se agrega un espacio debido a que se lee los caracteres y hasta que encuentre un espacio es una palabra
            
            //el for recorre caracter por caracter 
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;
                //switch que va leyendo los estados 
                //se le asigna cero como estado inicial
                switch (estado)
                {
                    case 0:
                        
                        if (Char.IsLetter(c))
                        {
                            //si es letra pasamos al estado 1
                            estado = 1;
                            lexema += c; //concatenenamos los caracteres para armar la palabra o letra
                        }
                        else if (Char.IsDigit(c))
                        {
                            //si es digito al estado 2
                            estado = 2;
                            lexema += c;
                        }
                        // si es " se asigna estado 4
                        else if (c == '"')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (c == ',')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        /*nuevos*/
                        else if (c == '{')
                        {
                            lexema += c;
                           

                            addToken(lexema, "llaveIzq", fila, columna, i - lexema.Length );
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "llaveDer", fila, columna, i - lexema.Length);
                           
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "parIzq", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "parDer", fila, columna, i - lexema.Length );
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            
                            lexema = "";
                        }

                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Punto y Coma", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "Menor", fila, columna , i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Mayor", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '.')
                        {
                            lexema += c;
                            addToken(lexema, "Punto", fila, columna, i - lexema.Length );
                            lexema = "";
                        }
 
                        /*fin nuevos*/

                        /*Operadores matematicos*/
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "Suma", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "Menos", fila, columna, i );
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "Multiplicacion", fila, columna, i );
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            addToken(lexema, "Division", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            addToken(lexema, "Igualdad", fila, columna, i);
                            lexema = "";
                        }
                        //fin operadoress matematicos

                        //en caso de que sea un caracter no reconocido se considera error lexico le doy un estado -99
                        else
                        {
                            estado = -99;
                            i--;
                            columna--;
                        }
                        break;
                   // para la creacion de variables con _
                    case 1:  
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                           
                        }
                        //si entra al else ya hemos terminado de leer la palabra o caracter ingresado
                        else
                        {
                            Boolean encontrado = false;
                            
                            encontrado = Macht_enReser(lexema);
                            
                            //verificar si la palabra ingresada es reservada o es un identificador
                            //a mi clase addtoken mando los parametros a guardar lexema, descrip, fila, columna
                            if (encontrado)
                            {
                                addToken(lexema, "Reservada", fila, columna, i - lexema.Length);
                            }
                            else
                            {
                                
                                addToken(lexema, "Identificador", fila, columna, i - lexema.Length);
                                }

                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        /*nuevo*/
                        else if (c == '.')
                        {
                            estado = 8;
                            lexema += c;
                        }
                        /*nuevo fin*/
                        else
                        {
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            estado = -99;
                            i = i - 2;
                            columna = columna - 2;
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        break;
                    case 6:
                        if (c == '"')
                        {
                            lexema += c;
                            //token = new Token(2, "Cadena", lexema, fila, columna);
                            //tokens.add(token);
                            addToken(lexema, "Cadena", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            //token = new Token(4, "Coma", lexema, fila, columna);
                            //tokens.add(token);
                            addToken(lexema, "Coma", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    /**inicio nuevo**/
                    case 8:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //retorno += "Se esperaba un digito[" + caracter + "]" + Environment.NewLine;
                            addError(lexema, "Se esperaba un digito [" + lexema + "]", fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //addToken(lexema, "decimal", pos + 1, 0);
                            //estado = 0;
                            //lexema = "";
                            //pos -= 1;
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }

                        break;
                    /*fin nuevo*/

                    case -99:
                        lexema += c;


                        addError(lexema, "Caracter Desconocido", fila, columna);

                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }

        public Boolean Macht_enReser(String sente)
        {
            Boolean enco = false;
            for (int i = 0; i < tokens.Count; ++i)
            {
                //MessageBox.Show(tokens[i].ToString(), sente);
                //(reservadas[i].Lexema.Equals(lexema)) a = reservadas[i].Id;
                if (sente.ToString() == tokens[i].ToString())
                {
                    enco = true;
                    estado_token = i;
                    return enco;
                }
                else { enco = false; }

            }
            return enco;
        }
       
        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = listaTokens.ElementAt(i);
                retorno += "[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
        }
        public String getRetorno()
        {
            return this.retorno;
        }
        
        //Retorno el listado que se ha guardado
        public List<Token> getListaTokens()
        {
           return listaTokens;
        }


    }
}
