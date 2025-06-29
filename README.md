AutoStocker.API (Presentation Layer)

	Kullan�c�dan gelen HTTP isteklerini kar��lar.
	Controller'lar burada yer al�r.
	Swagger, Rate Limiting, CSRF korumas�, XSS �nlemleri gibi API g�venlik yap�land�rmalar� buradad�r.

AutoStocker.Application (Service Layer / �� Ak���)

	�� mant��� ve i� ak��lar�n� i�erir.
	Servisler, DTO'lar (Data Transfer Objects) ve i� kurallar� burada bulunur.
	Veri eri�im katman�na (AutoStocker.Data) ba��ml�d�r.

AutoStocker.Domain (Core Business Layer)

	Entity, ValueObject, Enum ve Interface tan�mlamalar� burada yer al�r.
	Sistemin kurallar�n� tan�mlayan ana yap�.

AutoStocker.Infrastructure (Persistence & API Client Layer)

	Veritaban� ba�lant�s�, d�� API eri�imi, caching gibi teknik detaylar burada.
	EF Core, InMemory, veya dosya tabanl� veri eri�imleri buraya yaz�l�r.
	Fake Store API gibi d�� kaynaklara ula�an servislerin implemantasyonlar� burada.


SOLID ve Clean Architecture'da Yeri
	Katman			G�rev
	Domain			Aray�z (interface) tan�mlar � ne yap�laca��n� s�yler.
	Infrastructure	Aray�z� uygular � nas�l yap�laca��n� g�sterir.
	Application		�� mant���n� uygular � ne zaman yap�laca��n� belirler.







Notlar:

	Fake Store API da, e�ieltirme i�in productCode alan� yoktur.(pdf te aksi belirtilmektedir.