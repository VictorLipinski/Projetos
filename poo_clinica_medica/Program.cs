using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class Program
{
    public class Medico
    {
        public string Nome;
        public string CRM;
        public string Especialidade;

        public Medico(string crm, string especialdiade, string nome)
        {
            this.CRM = crm;
            this.Especialidade = especialdiade;
            this.Nome = nome;
        }
    }
    public class Paciente
    {
        public string Nome;
        public string CPF;
        public string DataNascimento;

        public Paciente(string nome, string cpf, string dataNascimento)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
        }

    }
    public class Consulta
    {
        int countC = 0;
        public int ID;
        public string DataConsulta;
        public string NomePaciente;
        public string NomeMedico;

        public Consulta(string dataConsulta, string nomePaciente, string nomeMedico)
        {
            this.ID = countC;
            countC++;
            this.DataConsulta = dataConsulta;
            this.NomePaciente = nomePaciente;
            this.NomeMedico = nomeMedico;
        }
    }
    public static void Main()
    {
        Dictionary<string, (string, string)> dictMedicos = new Dictionary<string, (string, string)>();
        Dictionary<string, (string, string)> dictPacientes = new Dictionary<string, (string, string)>();
        Dictionary<string, (string, string, string)> dictConsultas = new Dictionary<string, (string, string, string)>();

        Console.WriteLine("\nSeja bem-vindo!");
        Console.WriteLine("O que você deseja fazer?\n");
        Console.WriteLine("1. Cadastrar Médico\n2. Cadastrar Paciente\n3. Cadastrar Consulta\n4. Visualizar Médico\n5. Visualizar Paciente\n6. Visualizar Consulta\n7. Sair do programa");

        int option = int.Parse(Console.ReadLine()!);

        while (option != 7)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Informe os dados do Médico separados por espaço (Nome CRM Especialidade):\n");
                    string[] inputArrayMedico = Console.ReadLine()!.Split(" ");
                    (string, string) inputTupleMedico = (inputArrayMedico[1], inputArrayMedico[2]);
                    dictMedicos.Add(inputArrayMedico[0], inputTupleMedico);
                    break;
                case 2:
                    Console.WriteLine("Informe os dados do Paciente separados por espaço (Nome CPF Data de Nascimento):\n");
                    string[] inputArrayPaciente = Console.ReadLine()!.Split(" ");
                    (string, string) inputTuplePaciente = (inputArrayPaciente[1], inputArrayPaciente[2]);
                    dictPacientes.Add(inputArrayPaciente[0], inputTuplePaciente);
                    break;
                case 3:
                    Console.WriteLine("Informe os dados da consulta separados por espaço (ID Data Paciente Médico):\n");
                    string[] inputArrayConsulta = Console.ReadLine()!.Split(" ");
                    (string, string, string) inputTupleConsulta = (inputArrayConsulta[1], inputArrayConsulta[2], inputArrayConsulta[3]);
                    dictConsultas.Add(inputArrayConsulta[0], inputTupleConsulta);
                    break;
                case 4:
                    Console.WriteLine("Informe o nome do médico:\n");
                    string medicoNome = Console.ReadLine()!;

                    try
                    {
                        Console.WriteLine($"CRM: {dictMedicos[medicoNome].Item1}\nEspecialidade: {dictMedicos[medicoNome].Item2}\n");
                    }
                    catch
                    {
                        Console.WriteLine("Médico não encontrado...");
                    }
                    break;
                case 5:
                    Console.WriteLine("Informe o nome do paciente:\n");
                    string pacienteNome = Console.ReadLine()!;

                    try
                    {
                        Console.WriteLine($"CPF: {dictPacientes[pacienteNome].Item1}\nData de Nascimento: {dictPacientes[pacienteNome].Item2}\n");
                    }
                    catch
                    {
                        Console.WriteLine("Paciente não encontrado...");
                    }
                    break;
                case 6:
                    Console.WriteLine("Informe o código da consulta:\n");
                    string consultaCod = Console.ReadLine()!;

                    try
                    {
                        Console.WriteLine($"Data Consulta: {dictConsultas[consultaCod].Item1}\nPaciente: {dictConsultas[consultaCod].Item2}\nPaciente: {dictConsultas[consultaCod].Item3}");
                    }
                    catch
                    {
                        Console.WriteLine("Consulta não encontrada...");
                    }
                    break;
            }

            Console.WriteLine("O que você deseja fazer?\n");
            option = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("Até mais!");
    }    
}