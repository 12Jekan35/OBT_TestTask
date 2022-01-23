--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.1

-- Started on 2022-01-23 16:33:48

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 210 (class 1259 OID 16671)
-- Name: BudgetAccounts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."BudgetAccounts" (
    "ID" integer NOT NULL,
    "Code" text NOT NULL,
    "FormNumber" integer NOT NULL,
    "SintAccount" text NOT NULL,
    "KOSGU" text NOT NULL,
    "StartYearDebtID" integer NOT NULL,
    "ChangeUpDebtID" integer NOT NULL,
    "ChangeDownDebtID" integer NOT NULL,
    "EndReportPeriodDebtID" integer NOT NULL,
    "EndSamePastPeriodID" integer NOT NULL
);


ALTER TABLE public."BudgetAccounts" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16670)
-- Name: BudgetAccounts_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."BudgetAccounts" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."BudgetAccounts_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 214 (class 1259 OID 16688)
-- Name: ChangesDebt; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ChangesDebt" (
    "ID" integer NOT NULL,
    "AllSum" money DEFAULT 0 NOT NULL,
    "NonmonetaryPart" money DEFAULT 0 NOT NULL
);


ALTER TABLE public."ChangesDebt" OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 16687)
-- Name: ChangesDebt_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."ChangesDebt" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ChangesDebt_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 212 (class 1259 OID 16679)
-- Name: Debts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Debts" (
    "ID" integer NOT NULL,
    "AllSum" money DEFAULT 0 NOT NULL,
    "LongTerm" money DEFAULT 0 NOT NULL,
    "Overdue" money DEFAULT 0 NOT NULL
);


ALTER TABLE public."Debts" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16678)
-- Name: Debts_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Debts" ALTER COLUMN "ID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Debts_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3330 (class 0 OID 16671)
-- Dependencies: 210
-- Data for Name: BudgetAccounts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."BudgetAccounts" ("ID", "Code", "FormNumber", "SintAccount", "KOSGU", "StartYearDebtID", "ChangeUpDebtID", "ChangeDownDebtID", "EndReportPeriodDebtID", "EndSamePastPeriodID") FROM stdin;
\.


--
-- TOC entry 3334 (class 0 OID 16688)
-- Dependencies: 214
-- Data for Name: ChangesDebt; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ChangesDebt" ("ID", "AllSum", "NonmonetaryPart") FROM stdin;
\.


--
-- TOC entry 3332 (class 0 OID 16679)
-- Dependencies: 212
-- Data for Name: Debts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Debts" ("ID", "AllSum", "LongTerm", "Overdue") FROM stdin;
\.


--
-- TOC entry 3340 (class 0 OID 0)
-- Dependencies: 209
-- Name: BudgetAccounts_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BudgetAccounts_ID_seq"', 1, false);


--
-- TOC entry 3341 (class 0 OID 0)
-- Dependencies: 213
-- Name: ChangesDebt_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ChangesDebt_ID_seq"', 4632, true);


--
-- TOC entry 3342 (class 0 OID 0)
-- Dependencies: 211
-- Name: Debts_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Debts_ID_seq"', 36, true);


--
-- TOC entry 3180 (class 2606 OID 16677)
-- Name: BudgetAccounts BudgetAccounts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "BudgetAccounts_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 3184 (class 2606 OID 16694)
-- Name: ChangesDebt ChangesDebt_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ChangesDebt"
    ADD CONSTRAINT "ChangesDebt_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 3182 (class 2606 OID 16686)
-- Name: Debts Debts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Debts"
    ADD CONSTRAINT "Debts_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 3185 (class 2606 OID 16696)
-- Name: BudgetAccounts 1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "1" FOREIGN KEY ("StartYearDebtID") REFERENCES public."Debts"("ID") NOT VALID;


--
-- TOC entry 3186 (class 2606 OID 16701)
-- Name: BudgetAccounts 2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "2" FOREIGN KEY ("ChangeUpDebtID") REFERENCES public."ChangesDebt"("ID") NOT VALID;


--
-- TOC entry 3187 (class 2606 OID 16706)
-- Name: BudgetAccounts 3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "3" FOREIGN KEY ("ChangeDownDebtID") REFERENCES public."ChangesDebt"("ID") NOT VALID;


--
-- TOC entry 3188 (class 2606 OID 16711)
-- Name: BudgetAccounts 4; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "4" FOREIGN KEY ("EndReportPeriodDebtID") REFERENCES public."Debts"("ID") NOT VALID;


--
-- TOC entry 3189 (class 2606 OID 16716)
-- Name: BudgetAccounts 5; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BudgetAccounts"
    ADD CONSTRAINT "5" FOREIGN KEY ("EndSamePastPeriodID") REFERENCES public."Debts"("ID") NOT VALID;


-- Completed on 2022-01-23 16:33:48

--
-- PostgreSQL database dump complete
--

