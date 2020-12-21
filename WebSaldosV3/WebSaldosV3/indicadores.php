    <?php
    $xmlSource = "http://indicadoresdeldia.cl/webservice/indicadores.xml";
    $xml = simplexml_load_file($xmlSource);
    echo $xml->santoral->ayer;
    echo $xml->santoral->hoy;
    echo $xml->santoral->maniana;
    echo $xml->moneda->dolar;
    echo $xml->moneda->euro;
    echo $xml->moneda->dolar_clp; //Dolar interbancario
    echo $xml->indicador->ivp;
    echo $xml->indicador->uf;
    echo $xml->indicador->ipc;
    echo $xml->indicador->utm;
    echo $xml->indicador->imacec;
    echo $xml->bolsa->ipsa;
    echo $xml->bolsa->igpa;
    echo $xml->bolsa->banca;
    echo $xml->bolsa->commodities;
    echo $xml->bolsa->retail;
    echo $xml->bolsa->consumo;
    echo $xml->bolsa->utilities;
    ?>