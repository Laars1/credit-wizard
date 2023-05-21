# Teamarbeit
Wir haben uns in unserer Gruppe schnell zurecht gefunden, da wir bereits in anderen Modulen in ähnlicher Konstellation gearbeitet haben. Über die vergangenen 10-12 Wochen haben wir uns ein ambitioniertes Ziel gesetzt. In diesem Blogeintrag sprechen wir über unsere Zusammenarbeit, die Zielerreichung und was wir nächstes Mal anders machen würden.

# Zielerreichung
Zu Beginn des Projektes wurden diverse Ziele definiert, welche für einen erfolgreichen Abschluss des Projektes erfüllt werden müssen. Diese sind im Dokument [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx) detailliert beschrieben.
detailliert beschrieben. Untenstehend sind diese nochmals aufgeführt. Zusätzlich ist mittels der Checkbox angegeben, ob das Ziel abgeschlossen ist oder nicht:
- [x] Pflicht-Module und deren Erfüllungsgrad müssen ersichtlich sein
- [x] Diverse Module werden in unterschiedlichen Durchführungszeiträumen durchgeführt. Dieser Zeitraum muss für jedes Modul ersichtlich sein.
- [x] Übersicht: Es gibt ein Dashboard, auf welchem auf den ersten Blick alle Informationen zum Erfüllungsgrad des Studiums aufgeführt ist
- [x] Planung: Jeder Anwender soll sein Studium individuell planen und eintragen können

Zusätzlich wurde noch ein weiteres Ziel betreffend der Code Qualität hinzugefügt:
- [ ] •	 Im Frontend enthält jede Komponente und jede Klasse inkl. deren Methoden (ausgenommen OnInit(), welche zusätzlich erstellt wurden), einen Kommentar über deren Verwendungszweck.
- [x] Im .net Backend ist jede REST Schnittstelle, jeder Service und jede Erweiterungsklasse sowie Methode im Code dokumentiert.

## Stellungnahme
Auf den ersten Blick sind aktuell fast alle Ziele bereits erreicht. Aktuell noch offen ist die Code-Dokumentation im Frontend, welche noch nicht ganz zufriedenstellend ist. Ansonsten sind wir sehr zufrieden mit dem Ergebnis unserer Applikation. Die Applikation ist einfach zu bedienen und ist viel besser herausgekommen als erwartet. Daher sind wir zuversichtlich das auch noch das letzte Ziel vor dem Final Pitch abgeschlossen werden kann.

# Vorgenommene Anpassungen
Bereits im ersten Sprint mussten wir unsere Vision ein bisschen eingrenzen. In diesem Kapitel wurde beschrieben was und warum einige Funktionalitäten eingeschränkt werden mussten.

Dennoch können wir stolz sagen, dass wir während der Sprints keine Features einschränken oder sogar verwerfen mussten. Wir konnten unsere geplanten Arbeiten wie gewünscht umsetzen!

## Registrierungsseite
"Es wird keine Registrierungsseite geben, es gibt lediglich hinterlegte Benutzer, welche sich einloggen können" - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).

Bereits vor dem Start der Realisierung haben wir als Team entschiedenk, dass wir keine Registrierung umsetzen aufgrund der Komplexität. Im Nachhinein müssen wir zugeben, dass dieses Feature wohl trotzdem im Rahmen der Arbeit machbar gewesen wäre, da eigentlich im Backend nur ein API Call hinzugefügt werden musste und im Frontend nur ein Component. Dort haben wir wohl zu früh zu viel eingeschränkt.

## Studiengänge und Hochschulen
"In der umgesetzten Lösung wird nur der Studiengang «Bachelor of Science in Business Information Technology» der Berner Fachhochschule unterstützt werden." - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).
Weiter wurde unsere Vision auch nicht verfolgt, Studiengänge von anderen Schulen anzubieten.

Auch hier haben wir vor der Realisierung entschieden, dass standardmässig keine Studiengänge inkl. deren Modulen erfasst werden können. Diese sind direkt auf der Datenbank abgelegt. Dies wurde aufgrund des Zeitaufwandes so entschieden. Diese Entscheidung hat sich als passend erwiesen, da zu viele weitere Komponenten wie auch API Schnittstellen nötig gewesen wären, was den Rahmen des Projektes eindeutig gesprengt hätte.

# Arbeitsaufteilung
In diesem Kapitel ist niedergeschrieben, wer bis jetzt welche Tätigkeiten übernommen hat. Dies kann sich im Verlauf des Projektes natürlich noch ändern.

| Aufgabe                                     | Verantwortlich                        |
| ------------------------------------------- | ------------------------------------- |
| Präsentation                                | Lars / Niels                          |
| Entwicklung Frontend                        | Lars / Roman                          |
| Entwicklung Backend                         | Lars / Roman                          |
| Datenmodell                                 | Lars / Roman                          |
| Nutzeranalyse                               | Mikael / Janik / Niels                |
| Problemanalyse / Erfassen der Anforderungen | Mikael / Janik / Niels                |
| Analyse Ist-Zustand                         | Mikael / Janik / Niels                |
| Organisation der Arbeiten                   | Mikael / Janik / Niels / Lars / Roman |
|                                             |                                       |

Während der Sprint gab es oft nur kurze Wartezeiten. Unsere Gruppe teilte sich die Arbeit Modulübergreifend auf, sodass die Verantwortungen über die verschiedenen Module in diesem Semster aufgeteilt sind. So konnten wir unsere Stärken optimal ausspielen.

Durch die Arbeitsaufteilung arbeiteten nur selten mehr als 2-3 Personen direkt für dieses Modul. So konnen Überschneidungen und Wartezeiten minimiert werden. Teilweise musste für die Sprint Reviews Content noch spontan angepasst werden, da noch ein Feature kurzfristig fertiggestellt wurde.

# Lessons Learned
Dieses Modul basiert auf einer erfolgreichen Teamzusammenarbeit. Alles in allem können wir voraussichtlich alle unsere Ziele für die Applikation erreichen. Dennoch haben wir einige Dinge welche, wir das nächste Mal anders machen würden. Diese sind in diesem Kapitel aufgeführt.

## Technologieauswahl
Wir haben uns als Gruppe entschieden im Backend nicht auf Strapi sondern auf eine .Net Web API zu setzen. Dies aus dem Grund da Lars bereits mehrjährige Erfahrungen im .Net Umfeld sammeln konnte. Daher war auch er im Lead für die Entwicklung der API.
So hatten wir den Vorteil, dass wir eine API genau nach unseren Wünschen und Anforderungen entwickeln konnten. Diese erleichtere uns das Handling mit den Daten und der Businesslogik um ein vielfaches.

Dennoch würden wir beim nächsten Mal auf die empfohlenen Technologien setzen, denn uns wurde erst bei der Realisierung klar, dass wir einen viel grösseren Mehraufwand betreiben müssen. Denn gemäss Aufgabestellung müssen wir lediglich ein Frontend & eine Stapi Api erstellen und konfigurieren. Stattdessen haben wir zwei verschiedene Systeme, welche geplant und entwickelt werden mussten. Zudem musste noch eine Datenbank geplant und erstellt werden, damit die Daten effizient und konsistent abgespeichert werden können.

Dennoch haben wir die Entwicklung erfolgreich gemeistert. Dies ist jedoch ein wichtiges Learning für kommende Projekte.


## Adaptierung der Erwartungen
Zu Beginn waren wir sehr euphorisch, dass wir eine neue, innovative Applikation realisieren, mit welcher wir unser Studium einfach und effiziert planen und überwachen können. Nachdem uns jedoch klar wurde welch ein Aufwand damit verbunden war, merkten wir schnell, dass wir dies nicht alles neben allen anderen Modulen einfach so realisieren konnten. Wir wurden auf den Boden der Tatsachen zurückgeholt.

Unser Learing: Zum Beginn nicht in einen Tunnelblick verfallen, sondern auch andere Einflussfaktoren, wie Aufwände in anderen Modulen, Arbeiten vom Betrieb aus, etc. müssen bei der Planung von praktischen Projekten einberechnet werden. Ansonsten droht ein Berg von Arbeit, welcher nur schwer bewältigt werden kann. Dennoch sind wir uns auch für in der Zukunft sicher, dass wir uns ambitiöse Ziele setzen wollen, damit auch in Zukunft spannende und innovative Projekte entstehen