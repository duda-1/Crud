﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud._02_Repositorio.Data;

public static class InicializadorBd
{
    private const string ConnectionString = "Data Source=CRUD.db";

    public static void Inicializar()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Times(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    AnoCriacao INTEGER NOT NULL
                    );";

            commandoSQL += @"
                    CREATE TABLE IF NOT EXISTS Alunos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Idade INTEGER NOT NULL,
                    Peso REAL NOT NULL
                    );";
            commandoSQL += @"
                    CREATE TABLE IF NOT EXISTS Cidades(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeCidade TEXT NOT NULL,
                    NumHabitantes INTEGER NOT NULL
                    );";
            using (var command = new SQLiteCommand(commandoSQL, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
