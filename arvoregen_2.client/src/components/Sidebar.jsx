import React from "react";
import { Nav } from "react-bootstrap";
import { CIcon } from '@coreui/icons-react';
import {
    CBadge,
    CSidebar,
    CSidebarBrand,
    CSidebarHeader,
    CSidebarNav,
    CNavGroup,
    CNavItem,
    CNavTitle,
} from '@coreui/react'

import { cilSitemap, cilHome, cilPeople, cilPen, cilPlus } from '@coreui/icons'

const Sidebar = () => {
    return (
        <CSidebar className="border-end d-flex flex-column position-fixed vh-100" colorScheme="dark" style={{ width: "250px", top: 0, left: 0, zIndex: 100 }}>
            <CSidebarHeader className="border-bottom">
                <CSidebarBrand>Árvore Genealógica</CSidebarBrand>
            </CSidebarHeader>
            <CSidebarNav>
                <CNavItem href="/index">
                    <CIcon customClassName="nav-icon" icon={cilHome} /> Home
                </CNavItem>
                <CNavGroup
                    toggler={
                        <>
                            <CIcon customClassName="nav-icon" icon={cilPeople} /> Pessoas
                        </>
                    }
                >
                    <CNavItem href="/pessoas/adicionar">
                        <CIcon customClassName="nav-icon" icon={cilPlus} /> Inserir
                    </CNavItem>
                    <CNavItem href="/pessoas/visualizar">
                        <CIcon customClassName="nav-icon" icon={cilPen} /> Ver/Editar
                    </CNavItem>
                </CNavGroup>
                <CNavGroup
                    toggler={
                        <>
                            <CIcon customClassName="nav-icon" icon={cilSitemap} /> Relacionamentos
                        </>
                    }
                >
                    <CNavItem href="/relacionamentos">
                        <CIcon customClassName="nav-icon" icon={cilPlus} /> Inserir
                    </CNavItem>
                    <CNavItem href="/relacionamentos">
                        <CIcon customClassName="nav-icon" icon={cilPen} /> Ver/Editar
                    </CNavItem>
                </CNavGroup>
            </CSidebarNav>
        </CSidebar>
    );
};

export default Sidebar;
