using System.Collections;

namespace TiendaConsola.EstructurasDeDatos;

public class TADVector : IEnumerable<Producto>
{
    public int _longitud { get; set; }
    private Producto?[] _arr;
    private const int MaxVector = 1000;

    public TADVector()
    {
        _arr = new Producto[MaxVector];
        _longitud = 0;
    }

    public void AgregarElemento(Producto valor)
    {
        if (_longitud < MaxVector)
        {
            _arr[_longitud] = valor;
            _longitud++;
        }
        else
        {
            throw new InvalidOperationException("El vector esta lleno");
        }
    }

    public Producto ObtenerElemento(int pos)
    {
        if (pos >= _longitud || pos < 0)
            throw new AccessViolationException("La posicion es invalidad");
        return _arr[pos]!;
    }

    public override string ToString()
    {
        string? resp = "";
        for (int i = 0; i < _longitud; i++)
        {
            resp += _arr[i]!.ToString();
            resp += " ";
        }

        return resp;
    }
    
    public void InsertarElemento(int pos, Producto elemento)
    {
        if (pos < 0 || pos > _longitud) 
            throw new ArgumentOutOfRangeException(nameof(pos));
        if (_longitud >= MaxVector) 
            throw new InvalidOperationException("El vector esta lleno");

        for (int i = _longitud; i > pos; i--)
        {
            _arr[i] = _arr[i - 1];
        }

        _arr[pos] = elemento;
        _longitud++;
    }

    public void EliminarElemento(int pos)
    {
        if (pos < 0 || pos >= _longitud) return;

        for (int i = pos; i < _longitud - 1; i++)
        {
            _arr[i] = _arr[i + 1];
        }
        _arr[_longitud - 1] = null;
        _longitud--;
    }

    public IEnumerator<Producto> GetEnumerator()
    {
        for (int i = 0; i < _longitud; i++)
        {
            if (_arr[i] != null)
            {
                yield return _arr[i]!;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}