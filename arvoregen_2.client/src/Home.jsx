import React from 'react';
import { Container, Row, Col, Button, Card } from 'react-bootstrap';

const Home = () => {
    return (
        <Container className="mt-5">
            <h1 className="text-center mb-4">Bem-vindo à Página Inicial</h1>
            <Row>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Funcionalidade 1</Card.Title>
                            <Card.Text>
                                Descrição da funcionalidade 1. Isso pode ser um link ou informação útil. éééé
                            </Card.Text>
                            <Button variant="primary" href="/funcionalidade1">Acessar</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Funcionalidade 2</Card.Title>
                            <Card.Text>
                                Aqui você pode descrever a segunda funcionalidade do sistema.
                            </Card.Text>
                            <Button variant="success" href="/funcionalidade2">Acessar</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Sobre</Card.Title>
                            <Card.Text>
                                Clique para saber mais sobre o projeto.
                            </Card.Text>
                            <Button variant="info" href="/sobre">Ver Mais</Button>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
};

export default Home;
