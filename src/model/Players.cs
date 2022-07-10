using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Player:Interface_Players
    {
    // Atributos
    private string name;
    private int turno;
    private int puntos;

    // Metodo
    public Player(string name)
    {
        this.name = name;
        this.turno = 0;
        this.puntos = 0;
    }

    /**
     * Obtiene un Stringe con el nombre de un jugador
     * @return String name
     */
    public string getName()
    {
        return name;
    }

    /**
     * Modifica el nombre (String)
     * @ param name (String)
     */
    public void setName(string name)
    {
        this.name = name;
    }

    /**
     * Obetiene un Integer con el Turno de un jugador
     * @return Integer Turno
     */
    public int getTurno()
    {
        return turno;
    }

    /**
     * Modifica el turno (Integer)
     * @ param turno (Integer)
     */
    public void setTurno(int turno)
    {
        this.turno = turno;
    }

    /**
     * Obetiene un Integer con los Puntos de un jugador
     * @return Integer Puntos
     */
    public int getPuntos()
    {
        return puntos;
    }

    /**
     * Modifica los puntos (Integer)
     * @ param puntos (Integer)
     */
    public void setPuntos(int puntos)
    {
        this.puntos = puntos;
    }

    /**
     * Comprueba si un jugador (Player) es igual a otro
     * @return Boolean
     */
    public override bool Equals(Object o)
    {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        Player player = (Player)o;
        return Object.Equals(name, player.name) && Object.Equals(turno, player.turno) && Object.Equals(puntos, player.puntos);
    }

    /**
     * Convierte el contendio de Player a String
     * @return name, turno, puntos como String
     */
    public override string ToString()
    {
        return "Player{" +
                "name='" + name + '\'' +
                ", turno=" + turno +
                ", puntos=" + puntos +
                '}';
    }
}
}