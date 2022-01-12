using System;
using Bogus;
using System.Collections.Generic;

namespace GameCup.Models
{
    public class Game
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public float nota { get; set; }
        public int ano { get; set; }
        public string urlImagem { get; set; }

        public Game CompareGames(Game game1, Game game2){
            if (game1.nota > game2.nota)
            {
                return game1;
            }
            else if (game1.nota == game2.nota)
            {
                if (game1.ano > game2.ano)
                {
                    return game1;
                }
                else if (game1.ano == game2.ano)
                {
                    if(game1.titulo.CompareTo(game2.titulo) < 0 ){
                        return game1;
                    }else{
                        return game2;
                    }
                }
                else
                {
                    return game2;
                }
            }
            else
            {
                return game2;
            }
        }

        public List<Game> Eliminatorias(List<Game> games)
        {
            var games_quartas_final = new List<Game>();
            for (int i = 0; i < 4; i++)
            {
               games_quartas_final.Add(CompareGames(games[i], games[7 - i]));
            }
            return games_quartas_final;
        }

        public List<Game> Final(List<Game> games)
        {
            var games_final = new List<Game>();
            var game_chave1 = new Game();
            var game_chave2 = new Game();

            game_chave1 = CompareGames(games[0], games[1]);
            game_chave2 = CompareGames(games[2], games[3]);

            if(CompareGames(game_chave1,game_chave2) == game_chave1 ){
                games_final.Add(game_chave1);
                games_final.Add(game_chave2);
            }else{
                games_final.Add(game_chave2);
                games_final.Add(game_chave1);
            }

            return games_final;
        }

        public static Faker<Game> FakeData { get; } = 
            new Faker<Game>()
                .RuleFor(p => p.id, f => f.Random.String())
                .RuleFor(p => p.titulo, f => f.Commerce.Product())
                .RuleFor(p => p.nota, f => f.Random.Float())
                .RuleFor(p => p.ano, f => f.Random.Int())
                .RuleFor(p => p.urlImagem, f => f.Random.String());
    }
}
