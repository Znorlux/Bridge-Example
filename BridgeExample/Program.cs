// La "abstracción" define la interfaz para la parte de
// "control" de las dos jerarquías de clase. Mantiene una
// referencia a un objeto de la jerarquía de "implementación" y
// delega todo el trabajo real a este objeto.

public class Program
{
    public static void Main(String[] args)
    {
        Tv tv = new Tv();
        RemoteControl remote = new AdvancedRemoteControl(tv); // Usamos AdvancedRemoteControl en lugar de RemoteControl
        remote.TogglePower(); // Encender o apagar la TV

        // Ajustar el volumen de la TV
        remote.VolumeUp();
        remote.VolumeUp();
        remote.VolumeDown();

        // Cambiar de canal en la TV
        remote.ChannelUp();
        remote.ChannelUp();
        remote.ChannelDown();

        Radio radio = new Radio();
        remote = new AdvancedRemoteControl(radio); // Creamos una nueva instancia de AdvancedRemoteControl
        remote.TogglePower(); // Encender o apagar la radio

        // Ajustar el volumen de la radio
        remote.VolumeUp();
        remote.VolumeDown();

        // Cambiar de canal en la radio
        remote.ChannelUp();
        remote.ChannelDown();

        AdvancedRemoteControl advancedRemote = (AdvancedRemoteControl)remote; // Convertimos el control remoto a AdvancedRemoteControl
        advancedRemote.Mute(); // Silenciar la radio
    }

}
public abstract class RemoteControl
{
    protected Device device;

    public RemoteControl(Device device)
    {
        this.device = device;
    }

    public void TogglePower()
    {
        if (device.IsEnabled())
        {
            device.Disable();
        }
        else
        {
            device.Enable();
        }
    }

    public void VolumeDown()
    {
        device.SetVolume(device.GetVolume() - 10);
    }

    public void VolumeUp()
    {
        device.SetVolume(device.GetVolume() + 10);
    }

    public void ChannelDown()
    {
        device.SetChannel(device.GetChannel() - 1);
    }

    public void ChannelUp()
    {
        device.SetChannel(device.GetChannel() + 1);
    }
}

// Puedes extender clases de la jerarquía de abstracción
// independientemente de las clases de dispositivo.
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(Device device) : base(device)
    {
    }

    public void Mute()
    {
        device.SetVolume(0);
    }
}

// La interfaz de "implementación" declara métodos comunes a
// todas las clases concretas de implementación. No tiene por
// qué coincidir con la interfaz de la abstracción. De hecho,
// las dos interfaces pueden ser completamente diferentes.
// Normalmente, la interfaz de implementación únicamente
// proporciona operaciones primitivas, mientras que la
// abstracción define operaciones de más alto nivel con base en
// las primitivas.
public interface Device
{
    bool IsEnabled();
    void Enable();
    void Disable();
    int GetVolume();
    void SetVolume(int percent);
    int GetChannel();
    void SetChannel(int channel);
}

// Todos los dispositivos siguen la misma interfaz.
public class Tv : Device
{
    private bool isEnabled;
    private int volume;
    private int channel;

    public bool IsEnabled()
    {
        return isEnabled;
    }

    public void Enable()
    {
        isEnabled = true;
        Console.WriteLine("TV enabled.");
    }

    public void Disable()
    {
        isEnabled = false;
        Console.WriteLine("TV disabled.");
    }

    public int GetVolume()
    {
        return volume;
    }

    public void SetVolume(int percent)
    {
        volume = percent;
        Console.WriteLine($"TV volume set to {percent}%.");
    }

    public int GetChannel()
    {
        return channel;
    }

    public void SetChannel(int channel)
    {
        this.channel = channel;
        Console.WriteLine($"TV channel set to {channel}.");
    }
}

public class Radio : Device
{
    private bool isEnabled;
    private int volume;
    private int channel;

    public bool IsEnabled()
    {
        return isEnabled;
    }

    public void Enable()
    {
        isEnabled = true;
        Console.WriteLine("Radio enabled.");
    }

    public void Disable()
    {
        isEnabled = false;
        Console.WriteLine("Radio disabled.");
    }

    public int GetVolume()
    {
        return volume;
    }

    public void SetVolume(int percent)
    {
        volume = percent;
        Console.WriteLine($"Radio volume set to {percent}%.");
    }

    public int GetChannel()
    {
        return channel;
    }

    public void SetChannel(int channel)
    {
        this.channel = channel;
        Console.WriteLine($"Radio channel set to {channel}.");
    }
}