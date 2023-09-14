using Xunit;
using System.IO;
using System;
using TikTakToe;
using FluentAssertions;

namespace TikTakToe.Test;

[Collection("Sequential")]
public class TestTikTakToeGame
{
    [Theory(DisplayName = "Deve preencher o tabuleiro com o caractere correto na posição adequada")]
    [InlineData(
        1,
        1,
        'x',
        new char[] {
            ' ', ' ', ' ',
            ' ', 'x', ' ',
            ' ', ' ', ' '
        }
    )]
    public void TestMakeMove(int lineEntry, int columnEntry, char playerEntry, char[] expected)
    {
        var game = new TikTakToeGame();
        game.makeMove(lineEntry, columnEntry, playerEntry);
        game.board[lineEntry, columnEntry].Should().Be('x');

        char[,] _fromArrayToMultiDimArray = fromArrayToMultiDimArray(expected, 3, 3);
        game.board.Should().BeEquivalentTo(_fromArrayToMultiDimArray);
        game.board.Should().BeEquivalentTo(_fromArrayToMultiDimArray, options => options.ComparingByValue<char>());


    }
    
    [Theory(DisplayName = "Deve imprimir o tabuleiro")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        new string[] {
            "x x x",
            "x x x",
            "x x x"
        }
    )]
    public void TestPrintBoard(char[] entry, string[] expected)
    {      
        var game = new TikTakToeGame();
        char[,] _fromArrayToMultiDimArray = fromArrayToMultiDimArray(entry, 3, 3);
        game.board = _fromArrayToMultiDimArray;
        using (var stringWriter = new StringWriter())
        {
        Console.SetOut(stringWriter);
        game.printBoard();
        var result = stringWriter.ToString().Split('\n', 3);
        for (int i = 0; i < result.GetLength(0); i++)
        {
            result[i] = result[i].Trim();
        }
        result[0].Should().Be("x x x");
        result[1].Should().Be("x x x");
        result[2].Should().Be("x x x");
        result.Should().BeEquivalentTo(expected);
        result.Should().BeEquivalentTo(expected, options => options.ComparingByValue<string>());
        }
    }

    [Theory(DisplayName = "Deve retornar corretamente se o jogo acabou ou não")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        'x',
        true
    )]
    public void TestIsGameOver(char[] entry, char expectedWinner, bool expectedReturn)
    {
        var game = new TikTakToeGame();
        char[,] _fromArrayToMultiDimArray = fromArrayToMultiDimArray(entry, 3, 3);
        game.board = _fromArrayToMultiDimArray;
        bool result = game.isGameOver();
        result.Should().Be(expectedReturn);
        game.winner.Should().Be(expectedWinner);
    }

    [Theory(DisplayName = "Deve imprimir o vencedor correto do jogo")]
    [InlineData(' ', "Empate! Deu velha!")]
    public void TestPrintResults(char entry, string expected)
    {
        var game = new TikTakToeGame();
        game.winner = entry;
        string result;
        using (var stringWriter = new StringWriter())
        {
        Console.SetOut(stringWriter);
        game.printResults();
        result = stringWriter.ToString().Trim();
        }
        result.Should().Be(expected);
        game.winner.Should().Be(entry);
        
    }

    public static char[,] fromArrayToMultiDimArray(char[] array, int lines, int columns)
    {
        char[,] result = new char[lines, columns];
        for (int i = 0; i < array.Length; i++)
        {
            result[i / columns, i % columns] = array[i];
        }
        return result;
    }
}
