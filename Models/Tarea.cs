﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

public class Tarea
{
    public Guid TareaId {get;set;}
    public Guid CategoriaId {get;set;}
     public string Titulo {get;set;}
    public string descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    public string Resume {get;set;}
    public bool JorgieJOTO {get;set;}

}

public enum Prioridad{
    Baja,
    Media,
    Alta
}
