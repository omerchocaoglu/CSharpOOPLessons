# CSharpOOPLessons
## Bu repo [Patika.dev](https://www.patika.dev) tarafından verilen `CSharpOOPLessons` csharp projesini içermektedir.

Ödev - Üniversite Yönetim Sistemi

1 - Üniversiteye ait sınıflıklar, çalışma ofisleri ve departmanlar vardır.

2 - Departmanlara ait ofisler vardır.

3 - Üniversiteye ait çalışanlar vardır. Bu çalışanlar profesör veya memur olabilir.

4 - Her çalışan bir ofiste çalışır.

Bu sistemi tasvir eden Class (Sınıf) diyagramını çiziniz.

Not : Sınıflara ait nitelik ve davranışların belirtilmesine gerek yoktur.

            +-----------------+
            |   Universite    |
            +-----------------+
            | - sinifliklar   |<>----> [Sınıflık]
            | - ofisler       |<>----> [Ofis]
            | - departmanlar  |<>----> [Departman]
            +-----------------+

                          |
                          |
                          v
                 +----------------+
                 |   Departman    |
                 +----------------+
                 | - ofisler      |<>----> [Ofis]
                 +----------------+

                          |
                          |
                          v
                     +----------+
                     |  Ofis    |
                     +----------+

                          ^
                          |
                          |
           +--------------+----------------+
           |                               |
  +----------------+            +----------------+
  |   Calisan      |<---------->|   Ofis         |
  +----------------+            +----------------+
  |# Ad, Soyad vs. |                     
  +----------------+                     
           ^
           |
    +-------------+
    |             |
+-------------+ +-------------+
|  Profesör   | |   Memur     |
+-------------+ +-------------+
