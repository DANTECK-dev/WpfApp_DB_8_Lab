//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp_DB_8_Lab
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЮридическиеЛица
    {
        public int КодПоставщика { get; set; }
        public string Названия { get; set; }
        public string НалоговыйНомер { get; set; }
        public string НомерСвидетельства { get; set; }
    
        public virtual Поставщики Поставщики { get; set; }
    }
}
