using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using NetCoreAudio;

namespace MySoundboard;

public partial class MainWindow : Window
{
    private readonly Player _player = new();
    private double _volume = 100;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async Task PlaySound(string fileName)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", fileName);
        if (!File.Exists(path))
            return;

        await _player.Stop();
        await _player.Play(path);
        await _player.SetVolume((byte)_volume);
    }

    private async void BtnSound1_Click(object? sender, RoutedEventArgs e)
    {
        await PlaySound("1.mp3");
    }

    private async void BtnSound2_Click(object? sender, RoutedEventArgs e)
    {
        await PlaySound("2.mp3");
    }

    private async void BtnSound3_Click(object? sender, RoutedEventArgs e)
    {
        await PlaySound("3.mp3");
    }

    private async void BtnSound4_Click(object? sender, RoutedEventArgs e)
    {
        await PlaySound("4.mp3");
    }

    private async void SliderVolume_ValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        _volume = e.NewValue;
        if (_player.Playing)
            await _player.SetVolume((byte)_volume);
    }
}