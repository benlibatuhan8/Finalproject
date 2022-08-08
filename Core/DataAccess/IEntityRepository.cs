using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//Core katmanı diğer katmanları referans almaz.
namespace Core.DataAccess
{
    //Bu repoya sadece entity türlerin gelmesi lazım (product,category,customer gibi) yanlışlıkla int atma
    //Bunun için generic constraintleri kullanıcaz.
    //where T:class dediğimiz zaman sadece referans tip alabiliyor. Ama biz sadece IEntity implemente eden classları alıyoruz.
    //Buraya IEntity referansı gönderirsek soyut olur sadece onu implemente eden classların referansını göndermek istediğimiz için new()
    // new(): Newlenebilir olmalı. Ientity soyut olduğu için newlenemez.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filtre yaparak getirebilmemizi sağlayan yapı
        //ürünleri categoryye göre listele, fiayat aralıkları verip listele...
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //filter= null yapmak filtre vermeyedebilirsin demektir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      
    }
}
