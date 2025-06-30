
AutoStocker.API (Presentation Layer)

	Kullan�c�dan gelen HTTP isteklerini kar��lar.
	Swagger, Rate Limiting, CSRF korumas�, XSS �nlemleri gibi API g�venlik yap�land�rmalar� buradad�r.

AutoStocker.Application (Service Layer / �� Ak���)

	�� mant��� ve i� ak��lar�n� i�erir.
	Servisler, DTO'lar ve i� kurallar� burada bulunur.

AutoStocker.Domain (Core Business Layer)

	Entity, ValueObject, Enum ve Interface tan�mlamalar� burada yer al�r.
	Sistemin kurallar�n� tan�mlayan ana yap�.

AutoStocker.Infrastructure (Persistence & API Client Layer)

	Veritaban� ba�lant�s�, d�� API eri�imi, caching gibi teknik detaylar burada.
	EF Core, InMemory, veya dosya tabanl� veri eri�imleri buraya yaz�l�r.
	Fake Store API gibi d�� kaynaklara ula�an servislerin implemantasyonlar� burada.



ExceptionHandler
	API'de olu�abilecek hatalar� merkezi olarak yakalar ve uygun HTTP cevaplar�n� d�ner.
	ExceptionHandlingMiddleware ile pipeline'a eklendi. 
	Kullan�m �rne�i: Product/GetCsrfToken 'da ArgumentNullException ile yap�ld�.



Proje a��klamas� ve nas�l �al��t���:
	Api,
		Kullan�c�dan gelen istekleri al�r ve Application katman�ndaki servisleri �a��r�r.
	Application katman�,
		Domain Katman�ndaki repository aray�zleri (IProductRepository, IOrderRepository) ile veri katman�na eri�ir.
	Domain katman�
		Di�er katmanlar� tan�maz, eri�emez.Buy katmanda implementasyon yoktur, sadece interface tan�mlamalar� bulunur.
	Infrastructure 
		InMemoryProductRepository, InMemoryOrderRepository gibi repository implementasyonlar� i�erir
		D�� servisleri soyutlayan interface�leri (IFakeStoreClient) kullan�r. FakeStoreClient ile d�� API'den �r�n verisi �eker.

	
