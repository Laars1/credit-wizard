# Zielerreichung
Zu Beginn des Projektes wurden diverse Ziele definiert, welche für einen erfolgreichen Abschluss des Projektes erfüllt werden müssen. Diese sind im Dokument [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx) detailliert beschrieben.
Untenstehend sind diese nochmals Aufgeführt. Zusätzlich ist mittels der Checkbox angegeben ob das Ziel Abgeschlossen ist oder nicht:
- [x] Pflicht-Module und deren Erfüllungsgrad müssen ersichtlich sein
- [x] Diverse Module werden in unterschiedlichen Durchführungszeiträumen durchgeführt. Dieser Zeitraum muss für jedes Modul ersichtlich sein.
- [x] Übersicht: Es gibt ein Dashboard, auf welchem auf den ersten Blick alle Informationen zum Erfüllungsgrad des Studiums aufgeführt ist.
- [x] Planung: Jeder Anwender soll sein Studium individuell planen und eintragen können

Zusätzlich wurden noch ein weiteres Ziel betreffend der Code Qualität hinzugefügt:
- [ ] Im Frontend enhält jede Komponente und jede Klasse inkl. dernen Methoden (ausgenommen OnInit()) welche zusätzlich erstellt wurden einen Kommentar über deren Verwendungszweck.
- [x] Im .net Backend ist jede REST Schnittstelle, jeder Service und Erweiterungsklassen und Methoden im Code dokumentiert. 

## Stellungsnahme
Auf den ersten Blick sind aktuell fast alle Ziele bereits erreicht. Nur noch offen ist die Code Dokumenation im Frontend, welche noch nicht ganz zufriedenstellend ist. Ansonsten sind wir sehr zufrieden mit dem Ergebnis unserer Appliakation. Die Applikation ist einfach zu bedienen und ist viel besser herausgekommen als erwartet. Daher sind wir zuversichtlich das auch noch das letzte Ziel vor dem Final Pitch abgeschlossen werden kann.

# Vorgenommene Anpassungen
Bereits im ersten Sprint mussten wir unsere Vision ein bisschen eingrenzen. In diesem Kaptiel wurde beschrieben was und warum einige Funktionalitäten eingeschränkt werden mussten.

Dennoch können wir stolz sagen dass wir während der Sprints keine Features einschränken oder sogar verwerfen mussten. Wir konnten unsere geplanten Arbeiten wie gewünscht umsetzten!

## Registrierungsseite
"Es wird keine Registrierungsseite geben, es gibt lediglich hinterlegte Benutzer, welche sich einloggen können" - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).

Bereits vor dem Start der Realisierung haben wir als Team entschieden dass wir keine Registrierung umsetzen aufgrund der komplexität. Im nachhinein müssen wir zugeben das dieses Feature wohl trotzdem im Rahmen der Arbeit machbar gewesen wäre, da eigentlich im Backend nur einen API Call hinzugefügt werden musste und im Frontend nur eine Component. Dort haben wir uns wohl zu früh zu viel eingeschränkt.

## Studiengänge und Hochschulen
"In der umgesetzten Lösung wird nur der Studiengang «Bachelor of Science in Business Information Technology» der Berner Fachhochschule unterstützt werden." - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).
Weiter wurde unsere Vision auch nicht verfolgt, Studiengänge von anderen Schulen anzubieten.

Auch hier haben wir vor der Realisierung entschieden, dass standardmässig keine Studiengänge inkl. deren Modulen erfasst werden können. Diese sind direkt auf der Datenbank abgelegt. Dies wurde aufgrund des Zeitaufwandes so entschieden. Diese Entscheidung hat sich als passend erwiesen, da so viele weitere Komonenten wie auch API Schnittstellen nötig gewesen wären, was den Rahmen des Projektes einddeutig gesprängt hätte.