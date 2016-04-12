<?php

$post_data['userRole'] = 'Partner';
$post_data['userId'] = '003f005601409FoI6ABC';
$post_data['email'] = 'johnsmith@test.com';
$post_data['first'] = 'John';
$post_data['last'] = 'Smith';
$post_data['targetURL'] = '';
$post_data['organizationName'] = 'Fake, Inc.';
$post_data['organizationNumber'] = '000-000-000';
$post_data['address1'] = '123 Fake St.';
$post_data['address2'] = '';
$post_data['city'] = 'Seattle';
$post_data['region'] = 'WA';
$post_data['country'] = 'USA';
$post_data['postalCode'] = '98125';

$shared_key = 'SecretKeyDoNotShare';
$post_data['v'] = sha1($post_data['organizationNumber'] . $post_data['email'] . $shared_key);

foreach ( $post_data as $key => $value) {
    $post_items[] = $key . '=' . $value;
}

$post_string = implode ('&', $post_items);
$post_string = '?' . $post_string;

$data_length = strlen($post_string);
$connection = fsockopen('http://localhost:58156', 80);
fputs($connection, "POST  /SSOIn.aspx  HTTP/1.1\r\n");
fputs($connection, "Host:  http://localhost:58156/ \r\n");
fputs($connection, "Content-Type: application/x-www-form-urlencoded\r\n");
fputs($connection, "Content-Length: $data_length\r\n");
fputs($connection, "Connection: close\r\n\r\n");
fputs($connection, $post_string);

fclose($connection);