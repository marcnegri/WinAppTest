﻿using SQLite;  namespace WinAppTest {     // Interface de connexion à la DB embarquée     // Les classes qui en hérite sont dans chaque type de device : IOS ou Android     public interface ISQLite     {         SQLiteConnection GetConnection();     } }